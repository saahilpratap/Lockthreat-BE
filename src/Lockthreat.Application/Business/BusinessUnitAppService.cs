using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.DynamicEntityParameters;
using Abp.Linq.Extensions;
using Abp.Organizations;
using Abp.UI;
using Lockthreat.Business.Dto;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Common;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.Organizations;
using Lockthreat.Organizations.Dto;
using Lockthreat.OrganizationSetup;
using Lockthreat.OrganizationSetups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Business
{
    public class BusinessUnitAppService : LockthreatAppServiceBase,IBusinessUnitAppService
    {
        private readonly IOrganizationUnitAppService _organizationUnitAppService;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly IRepository<DynamicParameterValue> _DynamicParameterValueRepository;
        private readonly IRepository<DynamicParameter> _dynamicParameterManager;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;

        public BusinessUnitAppService(
            IRepository<BusinessUnit, long> businessUnitRepository,
            IOrganizationUnitAppService organizationUnitAppService,
            IRepository<OrganizationUnit, long> organizationUnitRepository,
            IRepository<LockThreatOrganization, long> organizationSetupRepository,
            IRepository<DynamicParameterValue> DynamicParameterValueRepository,
            IRepository<DynamicParameter> dynamicParameterManager,
            ICodeGeneratorCommonAppservice codegeneratorRepository,
            IRepository<Employees.Employee, long> employessRepository
            )
        {
            _businessUnitRepository = businessUnitRepository;
            _organizationUnitAppService = organizationUnitAppService;
            _organizationUnitRepository = organizationUnitRepository;
            _organizationSetupRepository = organizationSetupRepository;
            _DynamicParameterValueRepository = DynamicParameterValueRepository;
            _dynamicParameterManager = dynamicParameterManager;
            _codegeneratorRepository = codegeneratorRepository;
            _employessRepository = employessRepository;
        }

        public async Task<PagedResultDto<BusinessUnitListDto>> GetAllBusinessUnits(GetBusinessUnitInput input)
        {
            var query = _businessUnitRepository.GetAllIncluding().Include(x => x.UnitType).Include(y=>y.LockThreatOrganization)
                       .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId)
                       .WhereIf(input.UnitType != null, x => x.UnitTypeId == input.UnitType);

            var businessUnitCount = await query.CountAsync();
               
            var businessItems = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();
                  
           var businessListDtos = ObjectMapper.Map<List<BusinessUnitListDto>>(businessItems);

            businessListDtos.ForEach(obj =>
            {
                if (obj.ParentUnit != null)
                {
                    var getorganizationuint = _businessUnitRepository.FirstOrDefault(x => x.Id == obj.ParentUnit).BusinessUnitTitle;
                    obj.OraganizationUnitName = getorganizationuint;
                }
                if(obj.EmpId!=null)
                {
                    var employees = _employessRepository.GetAll().FirstOrDefault(x => x.Id == obj.EmpId).Name;
                    obj.EmployeeName = employees;
                }
            });

            return new PagedResultDto<BusinessUnitListDto>(
               businessUnitCount,
               businessListDtos.ToList()
               );
        }

        public async Task CreateOrUpdateBusinessUnit(CreateOrUpdateBusinessUnitInput input)
        {
            if (input.Id.HasValue)
            {
                await UpdateBusinessUnit(input);
            }
            else
            {
                await CreateBusinessUnit(input);
            }
        }
       
        private async Task CreateBusinessUnit(CreateOrUpdateBusinessUnitInput input)
        {

            var organizationItem = _organizationSetupRepository.GetAll().Where(x=>x.Id == input.LockThreatOrganizationId).FirstOrDefault();

            if (organizationItem != null)
            {
                //var organizationUnitCreateInput = new CreateOrganizationUnitInput()
                //{
                //    DisplayName = input.BusinessUnitTitle,
                //    ParentId = organizationItem.OrganizationUnitId
                //};

                var organizationUnitCreateInput  = new CreateOrganizationUnitInput();
                if (input.ParentUnit == null)
                {
                    organizationUnitCreateInput.DisplayName = input.BusinessUnitTitle;                 
                    organizationUnitCreateInput.ParentId = _organizationSetupRepository.GetAll().FirstOrDefault(x => x.Id == input.LockThreatOrganizationId).OrganizationUnitId;
                }
                else
                {
                    var oraganizationid = _businessUnitRepository.GetAll().FirstOrDefault(x => x.Id == input.ParentUnit).OrganizationUnitId;
                    organizationUnitCreateInput.DisplayName = input.BusinessUnitTitle;                  
                    organizationUnitCreateInput.ParentId = oraganizationid;
                }

                //create organization unit
                OrganizationUnitDto organizationUnitItem = await _organizationUnitAppService.CreateOrganizationUnit(organizationUnitCreateInput);

                if (organizationUnitItem != null)
                {
                    if (!input.TenantId.HasValue)
                    {
                        input.TenantId = AbpSession.TenantId;
                    }
                    input.OrganizationUnitId = organizationUnitItem.Id;
                    input.BusinessUnitId = _codegeneratorRepository.GetNextId(LockthreatConsts.Unit, "BUI");
                    var businessUnitItem = ObjectMapper.Map<BusinessUnit>(input);
                    await _businessUnitRepository.InsertAsync(businessUnitItem);
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.Unit, "BUI");

                }
            }
        }

        private async Task UpdateBusinessUnit(CreateOrUpdateBusinessUnitInput input)
        {

            try
            {
                if (input.Id == input.ParentUnit)
                {
                    throw new UserFriendlyException("Please Change Parent Unit");
                }
                else
                {
                    var organizationUnit = await _organizationUnitRepository.GetAsync((long)input.OrganizationUnitId); ;
                    if (organizationUnit != null)
                    {
                        if (organizationUnit.ParentId != input.OrganizationUnitId)
                        {
                            var moveOrganizationUnitInput = new MoveOrganizationUnitInput()
                            {
                                Id = organizationUnit.Id,
                                NewParentId = input.OrganizationUnitId
                            };
                            // move to new parent
                            //  await _organizationUnitAppService.MoveOrganizationUnit(moveOrganizationUnitInput);
                        }
                        var organizationUnitUpdateInput = new UpdateOrganizationUnitInput();
                        if (input.ParentUnit == null)
                        {
                            organizationUnitUpdateInput.DisplayName = input.BusinessUnitTitle;
                            organizationUnitUpdateInput.Id = organizationUnit.Id;
                            organizationUnitUpdateInput.ParentId = _organizationSetupRepository.GetAll().FirstOrDefault(x => x.Id == input.LockThreatOrganizationId).OrganizationUnitId;
                        }
                        else
                        {
                            var oraganizationid = _businessUnitRepository.GetAll().FirstOrDefault(x => x.Id == input.ParentUnit).OrganizationUnitId;
                            organizationUnitUpdateInput.DisplayName = input.BusinessUnitTitle;
                            organizationUnitUpdateInput.Id = organizationUnit.Id;
                            organizationUnitUpdateInput.ParentId = oraganizationid;
                        }

                        // update Organization Unit
                        OrganizationUnitDto organizationUnitItem = await _organizationUnitAppService.UpdateOrganizationUnit(organizationUnitUpdateInput);
                    }
                    else
                    {
                        throw new UserFriendlyException("CannotFindOrganizationUnit");
                    }

                    //update businessUnit
                    var businessItem = await _businessUnitRepository.GetAsync((long)input.Id);
                    if (businessItem != null)
                    {
                        ObjectMapper.Map(input, businessItem);
                        businessItem.TenantId = AbpSession.TenantId;
                        businessItem.BusinessUnitId = businessItem.BusinessUnitId;
                        await _businessUnitRepository.UpdateAsync(businessItem);
                    }
                }
            }
            catch(Exception ex)
            {
                throw;
            }

        }

        public async Task DeleteBusinessUnit(EntityDto input)
        {
            var businessItem = await _businessUnitRepository.GetAsync(input.Id);
            await _businessUnitRepository.DeleteAsync(businessItem);
        }

        public async Task<GetBusinessUnitForEditDto> GetBusinessUnitForEdit(EntityDto input)
        {
            GetBusinessUnitForEditDto businessUnitItem = new GetBusinessUnitForEditDto();
            var businessUnit = await _businessUnitRepository.GetAll().Include(x => x.LockThreatOrganization).FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == input.Id);

            if (businessUnit != null)
            {
                businessUnitItem = ObjectMapper.Map<GetBusinessUnitForEditDto>(businessUnit);
            }
            return businessUnitItem;
        }

        public string GetNextBusinessUnitId()
        {
            string nextBusinessUnitId = "";
            var businessUnitItem = _businessUnitRepository.GetAllList().LastOrDefault();
            if (businessUnitItem != null)
            {
                nextBusinessUnitId = "BUI-" + (businessUnitItem.Id + 1);
            }
            else
            {
                nextBusinessUnitId = "BUI-1";
            }

            return nextBusinessUnitId;
        }

       
        public async Task<List<UpdateOrganizationUnitInput>> GetAllOrganizationUnits()
        {
            var organizationUnitItem = new List<UpdateOrganizationUnitInput>();

            var query = await (from os in _organizationSetupRepository.GetAll()
                               join ou in _organizationUnitRepository.GetAll()
                               on os.OrganizationUnitId equals ou.Id
                               select ou).ToListAsync();

            organizationUnitItem = ObjectMapper.Map<List<UpdateOrganizationUnitInput>>(query);
            return organizationUnitItem;
        }

        public async Task<List<GetLockThreatOrganizationDto>> GetAllOraganization()
        {
             var organizationUnitItem = new List<GetLockThreatOrganizationDto>();
             var query = await (from os in _organizationSetupRepository.GetAll()
                                join ou in _organizationUnitRepository.GetAll()
                               on os.OrganizationUnitId equals ou.Id
                               select os).ToListAsync();
              organizationUnitItem = ObjectMapper.Map<List<GetLockThreatOrganizationDto>>(query);

             return organizationUnitItem;
        }

        public async Task<List<UnitTypeDto>> GetUnitType()
        {
            var getUnitType = new List<UnitTypeDto>();
            try
            {
                var getcheck = _dynamicParameterManager.GetAll().FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "unit type");
                if(getcheck!=null)
                {
                    getUnitType = await _DynamicParameterValueRepository.GetAll()
                        .Where(l => l.DynamicParameterId == getcheck.Id)
                         .Select(x => new UnitTypeDto()
                         {
                             Id = x.Id,
                             Name = x.Value,
                         }).OrderBy(x => x.Id).ToListAsync();

                    return getUnitType;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return getUnitType;
        }

        public async Task<List<BusinessUnitListDto>> GetAllparentUnit(UnitTypeInputDto input)
        {
            var result = new List<BusinessUnitListDto>();
            try
            {
                if (input.UnitTypeId != null)
                {
                    input.UnitTypeId.ForEach(obj =>
                    {
                        if (obj != 0)
                        {
                            var query =  _businessUnitRepository.GetAllIncluding().Include(x => x.UnitType)
                                         .WhereIf(input.UnitTypeId.Count() != 0, x => x.UnitTypeId == obj)
                                         .Include(y => y.LockThreatOrganization)
                                         .WhereIf(input.OraganizationId != null, x => x.LockThreatOrganizationId == input.OraganizationId);

                            var businessListDtos =  ObjectMapper.Map<List<BusinessUnitListDto>>(query);
                            businessListDtos.ForEach(Businessunit =>
                            {
                                result.Add(Businessunit);
                            });
                        }

                    });

                }      
              
            }
            catch(Exception ex)
            {
                throw;
            }
            return result;
        }

        public async Task<List<ParentUnit>> GetUnittypeWiesParent(UnitTypeInputDto input)
        {
            var result = new List<ParentUnit>();

            try
            {
                if (input.UnitTypeId != null)
                {
                    input.UnitTypeId.ForEach(obj =>
                    {
                        if (obj != 0)
                        {
                            var query = _businessUnitRepository.GetAllIncluding().Include(x => x.UnitType)
                                         .WhereIf(input.UnitTypeId.Count() != 0, x => x.UnitTypeId == obj)
                                         .Include(y => y.LockThreatOrganization)
                                         .WhereIf(input.OraganizationId != null, x => x.LockThreatOrganizationId == input.OraganizationId);

                            var businessListDtos = (from b in query
                                                   select new ParentUnit()
                                                   {
                                                       Id =b.Id,
                                                       BusinessUnitTitle=b.BusinessUnitTitle                                                           
                                                   }).ToList();

                            businessListDtos.ForEach(Businessunit =>
                            {
                                result.Add(Businessunit);
                            });
                        }

                    });

                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        [AbpAllowAnonymous]
        public async Task<List<BusinessUnitDto>> GetAllBusinessUnit(long OraganizationId )
        {
            var  businessUnitItem = new List<BusinessUnitDto>();
            try
            {
                var getBusinessUnit = await _businessUnitRepository.GetAll().Where(x => x.LockThreatOrganizationId == OraganizationId).OrderBy(x=>x.Id).ToListAsync();

                if (getBusinessUnit != null)
                {
                    businessUnitItem = ObjectMapper.Map<List<BusinessUnitDto>>(getBusinessUnit);
                }
                return businessUnitItem;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
     
    }
}
