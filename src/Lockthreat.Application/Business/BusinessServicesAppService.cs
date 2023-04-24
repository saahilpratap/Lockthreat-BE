using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessServices;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.ITservices.Dto;
using Lockthreat.ITServices;
using Lockthreat.OrganizationSetup.Dto;
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
    public class BusinessServicesAppService : LockthreatAppServiceBase, IBusinessServicesAppService
    {
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<BusinessService, long> _businessServicesRepository;
        private readonly BusinessUnitAppService _businessUnitAppService;
        private readonly IRepository<BusinessServiceUnit,long> _businessServiceunitRepository;
        private readonly IRepository<BusinessITService, long> _businessItServiceRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<BusinessServiceUnit, long> _businessServiceUnitRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly IRepository<ITService, long> _itservicesRepository;
        private readonly IRepository<ITServiceBusinessService, long> _ItServiceBusinessServiceRepository;

        public BusinessServicesAppService(
            IRepository<BusinessService, long> businessServicesRepository,
            BusinessUnitAppService businessUnitAppService,
            IRepository<BusinessServiceUnit, long> businessServiceunitRepository,
            IRepository<BusinessITService, long> businessItServiceRepository,
            ICodeGeneratorCommonAppservice codegeneratorRepository,
            IRepository<Employees.Employee, long> employessRepository,
            ICountriesAppservice countriesAppservice,
            IRepository<ITService, long> itservicesRepository,
            IRepository<BusinessUnit, long> businessUnitRepository ,
            IRepository<ITServiceBusinessService, long> ItServiceBusinessServiceRepository,
            IRepository<LockThreatOrganization, long> organizationSetupRepository,
            IRepository<BusinessServiceUnit, long> businessServiceUnitRepository
            )
           {
            _businessServiceunitRepository = businessServiceunitRepository;
            _businessServicesRepository = businessServicesRepository;
            _businessUnitAppService = businessUnitAppService;
            _businessItServiceRepository = businessItServiceRepository;
            _codegeneratorRepository = codegeneratorRepository;
            _employessRepository = employessRepository;
            _organizationSetupRepository = organizationSetupRepository;
            _countriesAppservice = countriesAppservice;
            _itservicesRepository = itservicesRepository;
            _businessUnitRepository = businessUnitRepository;
            _businessServiceUnitRepository = businessServiceUnitRepository;
            _ItServiceBusinessServiceRepository = ItServiceBusinessServiceRepository;
          }

        public async Task<BusinessServiceDto> GetBusinessSerivceInfo(long? ServiceId)
        {
            try
            {
                var BusinessService = new BusinessServiceDto();
                var BusinessServiceInfoById = new BusinessService();

                if (ServiceId > 0)
                {
                    BusinessServiceInfoById = await _businessServicesRepository.GetAll().FirstOrDefaultAsync(p => p.Id == ServiceId);
                }

                if (BusinessServiceInfoById.Id > 0)
                {
                    BusinessService = ObjectMapper.Map<BusinessServiceDto>(BusinessServiceInfoById);
                    BusinessService.SelectdBusinessUnits = ObjectMapper.Map<List<ServiceBusinessUnitDto>>(await _businessServiceunitRepository.GetAll().Where(p => p.BusinessServiceId == BusinessServiceInfoById.Id).ToListAsync());
                    BusinessService.SelectedItServices = ObjectMapper.Map<List<ITserviceBusinessServiceDto>>(await _ItServiceBusinessServiceRepository.GetAll().Where(p => p.BusinessServiceId == BusinessServiceInfoById.Id).ToListAsync());
                   // BusinessService.SelectedItServices = ObjectMapper.Map<List<ITserviceBusinessUnitDto>>(await _businessItServiceRepository.GetAll().Where(p => p.BusinessProcessId == BusinessServiceInfoById.Id).ToListAsync());                  
                }

                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                BusinessService.BusinessServiceOwners = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                BusinessService.BusinessUnits = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                BusinessService.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                BusinessService.ITserviceLists = ObjectMapper.Map<List<ITserviceListDto>>(await _itservicesRepository.GetAll().ToListAsync());
                BusinessService.Confidentialitys = await _countriesAppservice.GetAllConfidentiality();
                BusinessService.Otheres = await _countriesAppservice.GetAllOthers();
                BusinessService.Intergritys= await _countriesAppservice.GetAllIntergrity();
                BusinessService.ServiceTypes = await _countriesAppservice.GetAllServiceType();
                BusinessService.Availibilitys= await _countriesAppservice.GetAvailibility();  
                return BusinessService;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PagedResultDto<BusinessServicesListDto>> GetAllBusinessServicesList(GetBusinessServicesInput input)
        {
            try
            {
                var query = _businessServicesRepository.GetAllIncluding().
                    Include(x => x.Confidentiality).
                    Include(c => c.Intergrity).
                    Include(y => y.LockThreatOrganization).
                    Include(d => d.ServiceType).
                    Include(e => e.Others).
                    Include(f => f.BusinessUnitDependent).
                    Include(g => g.BusinessUnitprimary).
                    Include(xx => xx.Availibility)
                   .Include(yy => yy.BusinessServiceOwner)
                   .Include(cc => cc.BusinessServiceManager)
                   .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);

                var businessServicesCount = await query.CountAsync();

                var businsessServicesItems = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var businessListDtos = ObjectMapper.Map<List<BusinessServicesListDto>>(businsessServicesItems);

                return new PagedResultDto<BusinessServicesListDto>(
                   businessServicesCount,
                   businessListDtos
                   );
            }
            catch(Exception ex)
            {
                throw;
            }
        }


        public async Task CreateOrUpdateBusinessServices(BusinessServiceDto  input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.BusinessServiceId))
                {
                    input.BusinessServiceId  = _codegeneratorRepository.GetNextId(LockthreatConsts.BusinessService, "BSR");
                }
                 input.TenantId = AbpSession.TenantId;
                if (input.Id > 0)
                {
                    if (input.RemovedBusinessUnits != null)
                    {
                        foreach (var unitId   in input.RemovedBusinessUnits)
                        {
                            bool exist = _businessServiceUnitRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemoveBusinessUnit(unitId);
                            }
                        }
                    }
                    if (input.RemovedItServices != null)
                    {
                        foreach (var ext in input.RemovedItServices)
                        {
                            bool exist = _ItServiceBusinessServiceRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveItService(ext);
                            }
                        }
                    }                   
                }
                await _businessServicesRepository.InsertOrUpdateAsync(ObjectMapper.Map<BusinessService>(input));
                if (input.Id == 0)
                {
                   await _codegeneratorRepository.CodeCreate(LockthreatConsts.BusinessService, "BSR");
                }

            

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveItService(long id)
        {
            try
            {
                var itservice  = await _ItServiceBusinessServiceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _ItServiceBusinessServiceRepository.DeleteAsync(itservice);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveBusinessUnit (long id)
        {
            try
            {
                var employee = await _businessServiceUnitRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _businessServiceUnitRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }     
        public async Task<GetBusinessServicesForEditDto> GetBusinessServiceForEdit(EntityDto input)
        {

          
            GetBusinessServicesForEditDto businessServices = new GetBusinessServicesForEditDto();
            var businessItem = await _businessServicesRepository.GetAllIncluding().IgnoreQueryFilters().Where(x => !x.IsDeleted && x.Id == input.Id).FirstOrDefaultAsync();

            if (businessServices != null)
            {
                businessServices = ObjectMapper.Map<GetBusinessServicesForEditDto>(businessItem);
            }
            return businessServices;
        }               
        public async Task RemoveBusinessService(long ServiceId)
        {
            try
            {
                var businessService  = await _businessServicesRepository.GetAll().Where(p => p.Id == ServiceId).Include(p => p.SelectdBusinessUnits).Include(x => x.SelectedItServices).FirstOrDefaultAsync();

                if (businessService.SelectdBusinessUnits.Count > 0)
                {
                    foreach (var item in businessService.SelectdBusinessUnits)
                    {
                        await RemoveBusinessUnit(item.Id);
                    }
                }

                if (businessService.SelectedItServices.Count > 0)
                {
                    foreach (var item in businessService.SelectedItServices)
                    {
                        await RemoveItService(item.Id);
                    }
                }
                await _businessServicesRepository.DeleteAsync(businessService);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
             
    }
}
