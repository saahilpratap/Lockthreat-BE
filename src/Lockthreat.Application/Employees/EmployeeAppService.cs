using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Lockthreat.Employees;
using Lockthreat.Employee.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Lockthreat.Employee;
using Lockthreat.Authorization.Users.Dto;
using Lockthreat.Authorization.Users;
using Microsoft.AspNetCore.Identity;
using Abp.Extensions;
using System.Collections.ObjectModel;
using Abp.Authorization.Users;
using Lockthreat.Authorization.Roles;
using Lockthreat.Notifications;
using Abp.Notifications;
using Lockthreat.Url;
using Abp.UI;
using Lockthreat.Organizations;
using Lockthreat.Organizations.Dto;
using Lockthreat.BusinessEntities;
using System.Net.Mail;
using System.Net;
using Lockthreat.Common;
using Lockthreat.GRCPrograms.Dto;

namespace Lockthreat.Employees
{
    public class EmployeeAppService : LockthreatAppServiceBase, IEmployeeAppService
    {
        public IAppUrlService AppUrlService { get; set; }

        private readonly IRepository<Employee, long> _employessRepository;
        private readonly IUserAppService _userAppService;
        private readonly UserManager _userManager;
        private readonly IRepository<User, long> _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IEnumerable<IPasswordValidator<User>> _passwordValidators;
        private readonly RoleManager _roleManager;
        private readonly INotificationSubscriptionManager _notificationSubscriptionManager;
        private readonly IAppNotifier _appNotifier;
        private readonly IUserEmailer _userEmailer;
        private readonly IOrganizationUnitAppService _organizationUnitAppService;
        public long[] tempUserIds = new long[1];
        private readonly IRepository<BusinessUnit, long> _bussinessUnitRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        public EmployeeAppService(
            IRepository<Employee, long> employessRepository,
            IUserAppService userAppService,
            UserManager userManager,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            RoleManager roleManager,
            INotificationSubscriptionManager notificationSubscriptionManager,
            IAppNotifier appNotifier,
            IUserEmailer userEmailer,
            IRepository<User, long> userRepository,
            IOrganizationUnitAppService organizationUnitAppService,
            IRepository<BusinessUnit, long> bussinessUnitRepository,
            ICodeGeneratorCommonAppservice codegeneratorRepository
            )
        {
            _employessRepository = employessRepository;
            _userAppService = userAppService;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _passwordValidators = passwordValidators;
            _roleManager = roleManager;
            _notificationSubscriptionManager = notificationSubscriptionManager;
            _appNotifier = appNotifier;
            _userEmailer = userEmailer;
            _userRepository = userRepository;
            _organizationUnitAppService = organizationUnitAppService;
            _bussinessUnitRepository = bussinessUnitRepository;
            AppUrlService = NullAppUrlService.Instance;
            _codegeneratorRepository = codegeneratorRepository;
        }


        public async Task<PagedResultDto<EmployeeListDto>> GetAllEmployees(GetEmployeeInput input)
        {
            var query = _employessRepository.GetAll().Include(x => x.LockThreatOrganization).Include(x => x.BusinessUnit).Include(x => x.User);

            var employeeCount = await query.CountAsync();

            var empItems = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var employeeListDtos = ObjectMapper.Map<List<EmployeeListDto>>(empItems);
            return new PagedResultDto<EmployeeListDto>(
               employeeCount,
               employeeListDtos.ToList()
               );
        }

        public async Task CreateOrUpdateEmployees(CreateOrUpdateEmployeesInput input)
        {
            if (input.Id.HasValue)
            {
                await UpdateUser(input);
                await UpdateEmployees(input);
                
            }
            else
            {
                await CreateEmployees(input);
            }
        }

        private async Task CreateEmployees(CreateOrUpdateEmployeesInput input)
        {
            try
            {
                if (!input.TenantId.HasValue)
                {
                    input.TenantId = AbpSession.TenantId;
                }

                var userItem = ObjectMapper.Map<UserEditDto>(input);
                string LastName = "";
                string Name = "";
                string[] authorsList = input.Name.Split(" ");

                for (int i = 0; i < (authorsList.Length - 1); i++)
                {
                    Name = Name + " " + authorsList[i];
                    LastName = authorsList[authorsList.Length - 1];
                }

                userItem.Name = Name.ToString();
                userItem.Surname = LastName.ToString();
                userItem.EmailAddress = input.EmailAddress;
                 //var result = string.Join(" ", input.Name.Split().Skip(1));
                 //  if(result.Trim()=="" || result.Trim()==null)
                 //  {
                 //   userItem.Surname = "";
                 //  }
                 //  else
                 //  {
                 //   userItem.Surname = result.ToString();
                 //   }
                 
                
                CreateOrUpdateUserInput userDetails = new CreateOrUpdateUserInput()
                {
                    User = userItem,
                    SendActivationEmail = false,
                    SetRandomPassword = false
                };

                var user = ObjectMapper.Map<User>(userDetails.User); //Passwords is not mapped (see mapping configuration)              
                user.TenantId = AbpSession.TenantId;
                user.UserName = input.UserName;
               // user.Surname = "";
                user.IsActive = true;

                //Set password
                if (userDetails.SetRandomPassword)
                {
                    var randomPassword = await _userManager.CreateRandomPassword();
                    user.Password = _passwordHasher.HashPassword(user, randomPassword);
                    userDetails.User.Password = randomPassword;
                }
                else if (!userDetails.User.Password.IsNullOrEmpty())
                {
                    await UserManager.InitializeOptionsAsync(AbpSession.TenantId);
                    foreach (var validator in _passwordValidators)
                    {
                        CheckErrors(await validator.ValidateAsync(UserManager, user, userDetails.User.Password));
                    }

                    user.Password = _passwordHasher.HashPassword(user, userDetails.User.Password);
                }

                user.ShouldChangePasswordOnNextLogin = userDetails.User.ShouldChangePasswordOnNextLogin;

                //Assign roles
                user.Roles = new Collection<UserRole>();
                if (userDetails.AssignedRoleNames != null && userDetails.AssignedRoleNames.Length > 0)
                {
                    foreach (var roleName in userDetails.AssignedRoleNames)
                    {
                        var role = await _roleManager.GetRoleByNameAsync(roleName);
                        user.Roles.Add(new UserRole(AbpSession.TenantId, user.Id, role.Id));
                    }
                }

                CheckErrors(await UserManager.CreateAsync(user));
                await CurrentUnitOfWork.SaveChangesAsync(); //To get new user's Id.

                //Notifications
                //await _notificationSubscriptionManager.SubscribeToAllAvailableNotificationsAsync(user.ToUserIdentifier());
                await _appNotifier.WelcomeToTheApplicationAsync(user);

                //Organization Units
                //await UserManager.SetOrganizationUnitsAsync(user, userDetails.OrganizationUnits.ToArray());

                //Send activation email
                if (userDetails.SendActivationEmail)
                {
                     user.SetNewEmailConfirmationCode();
                     await _userEmailer.SendEmailActivationLinkAsync(
                        user,
                        AppUrlService.CreateEmailActivationUrlFormat(AbpSession.TenantId),
                        userDetails.User.Password
                    );
                }

                if (user.Id != 0)
                {
                    // add user to businessUnit (organization unit)
                    if(input.BusinessUnitId!=0 || input.BusinessUnitId!=null)
                    {

                  
                    var businessUnitItem = await _bussinessUnitRepository.GetAsync((long)input.BusinessUnitId);
                    if (businessUnitItem != null)
                    {
                        tempUserIds[0] = (long)user.Id;
                        UsersToOrganizationUnitInput userInput = new UsersToOrganizationUnitInput()
                        {
                            OrganizationUnitId = (long)businessUnitItem.OrganizationUnitId,
                            UserIds = tempUserIds
                        };

                        await _organizationUnitAppService.AddUsersToOrganizationUnit(userInput);
                    }
                  }
                    // insert into employee
                    input.UserId = user.Id;
                    var employeeItem = ObjectMapper.Map<Employees.Employee>(input);
                    employeeItem.Email = input.EmailAddress;
                    employeeItem.User = null;
                    if (string.IsNullOrEmpty(input.EmployeeId))
                    {
                        employeeItem.EmployeeId = _codegeneratorRepository.GetNextId(LockthreatConsts.Employee, "EMP");
                    }
                    await _employessRepository.InsertAsync(employeeItem);
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.Employee, "EMP");
                }
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }
        }

        private async Task UpdateEmployees(CreateOrUpdateEmployeesInput input)
        {
            try
            {
                var empItem = await _employessRepository.GetAsync((long)input.Id);
                empItem.Email = input.EmailAddress;
                ObjectMapper.Map(input, empItem);

                string LastName = "";
                string Name = "";
                string[] authorsList = input.Name.Split(" ");

                for (int i = 0; i < (authorsList.Length - 1); i++)
                {
                    Name = Name + " " + authorsList[i];
                    LastName = authorsList[authorsList.Length - 1];
                }

                empItem.User.Name = Name.ToString();
                empItem.User.Surname = LastName.ToString();
                var id= _employessRepository.InsertOrUpdateAndGetId(empItem);

                       
                // update Employees
               
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);

            }
        }

        public async Task UpdateUser(CreateOrUpdateEmployeesInput input)
        {
            try
            {
                var user = await _userRepository.FirstOrDefaultAsync((long)input.UserId.Value);

                var userItem = new UserEditDto()
                {
                    Id = user.Id,
                    EmailAddress = input.EmailAddress,
                    PhoneNumber = input.DirectPhone,
                    UserName = user.UserName,
                   
                };
                string LastName = "";
                string Name = "";
                string[] authorsList = input.Name.Split(" ");
                
                    for(int i=0;i<(authorsList.Length - 1);i++)
                    { 
                        Name = Name +" "+ authorsList[i];
                        LastName = authorsList[authorsList.Length - 1];
                    }
                   userItem.Name = Name.ToString();   
                   userItem.Surname = LastName.ToString();                
                ////Update user properties
                ObjectMapper.Map(userItem, user); //Passwords is not mapped (see mapping configuration)
                var id=   _userRepository.InsertOrUpdateAndGetId(user);

            }
           catch(Exception ex)
            {
                throw;

            }

        }
        public async Task<GetEmployeeForEditDto> GetEmployeesForEdit(EntityDto input)
        {
            GetEmployeeForEditDto empItem = new GetEmployeeForEditDto();
            var employee = await _employessRepository.GetAll().Include(x => x.LockThreatOrganization).Include(x => x.User).Include(x => x.BusinessUnit).Where(x => x.Id == input.Id).Include(x=>x.User).FirstOrDefaultAsync();

            if (employee != null)
            {
                empItem = ObjectMapper.Map<GetEmployeeForEditDto>(employee);
            }
            return empItem;
        }

        public async Task DeleteEmployee(EntityDto input)
        {
            try
            {
                var empItem = await _employessRepository.GetAsync(input.Id);

                var user = await UserManager.GetUserByIdAsync((long)empItem.UserId);
                await UserManager.DeleteAsync(user);

                await _employessRepository.DeleteAsync(empItem);
            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }

        }

        public string GetNextEmployeeId()
        {
            string nextEmployeeId = "";
            var empItem = _employessRepository.GetAllList().LastOrDefault();
            if (empItem != null)
            {
                nextEmployeeId = "EMP-" + (empItem.Id + 1);
            }
            else
            {
                nextEmployeeId = "EMP-1";
            }

            return nextEmployeeId;

        }

        public async Task<List<ProgramUser>> GetAllEmployeeOraganization(long? Id)
        {
            try
            {
                var getemployee = new List<ProgramUser>();
                if (Id != null)
                {
                    var employees = await _employessRepository.GetAll().Where(x => x.LockThreatOrganizationId == Id).Include(e => e.LockThreatOrganization).ToListAsync();
                    getemployee = ObjectMapper.Map<List<ProgramUser>>(employees);
                }
                return getemployee;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<List<GetEmployeeUnderOraganizationDto>> GetEmployeeForOraganization(long orgId)
        {
            var getemployee = new List<GetEmployeeUnderOraganizationDto>();
            try
            {
                var query = await _employessRepository.GetAll().Where(x => x.LockThreatOrganizationId == orgId).ToListAsync();
                if (query != null)
                {
                    getemployee = ObjectMapper.Map<List<GetEmployeeUnderOraganizationDto>>(query);

                }
                return getemployee;
            }
            catch(Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> CheckUserAvailable(string UserName) 
        {
            var getuserexit = await _userRepository.GetAll().Where(x => x.NormalizedUserName == UserName).AnyAsync();
            
            return getuserexit;

        }


   

    }
}
