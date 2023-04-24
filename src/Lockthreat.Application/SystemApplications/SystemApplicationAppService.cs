using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessProcesses;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.ITServices;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.OrganizationSetups;
using Lockthreat.SystemApplications.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;

namespace Lockthreat.SystemApplications
{
  public  class SystemApplicationAppService : LockthreatAppServiceBase
    {
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<ITService, long> _itservicesRepository;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<BusinessProcess, long> _businessProcessRepository;
        private readonly IRepository<BusinessService, long> _businessServicesRepository;
        private readonly IRepository<SystemApplication, long> _systeamApplicationRepository;
        private readonly IRepository<SysteamApplicationBusinessProcess, long> _systeamApplicationBusinessProcessRepository;
        private readonly IRepository<SysteamApplicationITservice, long> _systeamApplicationITserviceRepository;
        private readonly IRepository<SystemApplicationService, long> _systemApplicationServiceRepository;
        public SystemApplicationAppService (
         ICountriesAppservice countriesAppservice,
         IRepository<LockThreatOrganization, long> organizationSetupRepository,
         IRepository<Employees.Employee, long> employessRepository,
         IRepository<SysteamApplicationBusinessProcess, long> systeamApplicationBusinessProcessRepository,
         IRepository<SystemApplicationService, long> systemApplicationServiceRepository,
         IRepository<SysteamApplicationITservice, long> systeamApplicationITserviceRepository,
         IRepository<BusinessUnit, long> businessUnitRepository,
         IRepository<BusinessProcess, long> businessProcessRepository,
         IRepository<BusinessService, long> businessServicesRepository,
         IRepository<ITService, long> itservicesRepository,
         ICodeGeneratorCommonAppservice codegeneratorRepository,
         IRepository<SystemApplication, long> systeamApplicationRepository
         )
        {
            _countriesAppservice = countriesAppservice;
            _organizationSetupRepository = organizationSetupRepository;
            _codegeneratorRepository = codegeneratorRepository;
            _systeamApplicationRepository = systeamApplicationRepository;
            _employessRepository = employessRepository;
            _itservicesRepository = itservicesRepository;
            _businessUnitRepository = businessUnitRepository;
            _businessProcessRepository = businessProcessRepository;
            _businessServicesRepository = businessServicesRepository;
            _systeamApplicationBusinessProcessRepository = systeamApplicationBusinessProcessRepository;
            _systemApplicationServiceRepository = systemApplicationServiceRepository;
            _systeamApplicationITserviceRepository = systeamApplicationITserviceRepository;
        }

        public async Task<SystemApplicationDto> GetAllSystemApplication (long? assetId)
        {
            try
            {
                var systemApplication  = new SystemApplicationDto();
                var systemApplicationById  = new SystemApplication();
                if (assetId > 0)
                {
                    systemApplicationById = await _systeamApplicationRepository.GetAll().FirstOrDefaultAsync(p => p.Id == assetId);
                }
                if (systemApplicationById.Id > 0)
                {
                    systemApplication = ObjectMapper.Map<SystemApplicationDto>(systemApplicationById);
                    systemApplication.SelectedSysteamApplicationITservices = ObjectMapper.Map<List<SysteamApplicationITserviceDto>>(await _systeamApplicationITserviceRepository.GetAll().Where(p => p.SystemApplicationId == systemApplicationById.Id).ToListAsync());
                    systemApplication.SelectedSysteamApplicationBusinessProcess = ObjectMapper.Map<List<SysteamApplicationBusinessProcessDto>>(await _systeamApplicationBusinessProcessRepository.GetAll().Where(p => p.SystemApplicationId == systemApplicationById.Id).ToListAsync());
                    systemApplication.SelectedSystemApplicationServices = ObjectMapper.Map<List<SystemApplicationServiceDto>>(await _systemApplicationServiceRepository.GetAll().Where(p => p.SystemApplicationId == systemApplicationById.Id).ToListAsync());
                }
                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                systemApplication.EmployeesList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                systemApplication.BusinessUnitGaurdians= ObjectMapper.Map<List<BusinessUnitGaurdianDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                systemApplication.BusinessUnits = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                systemApplication.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                systemApplication.Confidentialitys = await _countriesAppservice.GetAllConfidentiality();
                systemApplication.Otheres = await _countriesAppservice.GetAllOthers();
                systemApplication.Integritys = await _countriesAppservice.GetAllIntergrity();
                systemApplication.Availibilitys = await _countriesAppservice.GetAvailibility();
                systemApplication.Countries = await _countriesAppservice.GetAll();
                systemApplication.ITserviceLists = ObjectMapper.Map<List<ITserviceListDto>>(await _itservicesRepository.GetAll().ToListAsync());
                systemApplication.BusinessProcess = ObjectMapper.Map<List<BusinessProcessDetailDto>>(await _businessProcessRepository.GetAll().ToListAsync());
                systemApplication.BusinessServices = ObjectMapper.Map<List<BusinessServiceSDto>>(await _businessServicesRepository.GetAll().ToListAsync());
                return systemApplication;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task CreateOrUpdateSystemApplication (SystemApplicationDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.SystemId))
                {
                    input.SystemId = _codegeneratorRepository.GetNextId(LockthreatConsts.SYS, "SYS");
                }
                input.TenantId = AbpSession.TenantId;
              
                if (input.Id > 0)
                {
                    if (input.RemovedSysteamApplicationITservice != null)
                    {
                        foreach (var unitId in input.RemovedSysteamApplicationITservice)
                        {
                            bool exist = _systeamApplicationITserviceRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemoveItService(unitId);
                            }
                        }
                    }

                    if (input.RemovedSysteamApplicationBusinessProcess != null)
                    {
                        foreach (var ext in input.RemovedSysteamApplicationBusinessProcess)
                        {
                            bool exist = _systeamApplicationBusinessProcessRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessProcess(ext);
                            }
                        }
                    }

                    if (input.RemovedSystemApplicationService != null)
                    {
                        foreach (var ext in input.RemovedSystemApplicationService)
                        {
                            bool exist = _systemApplicationServiceRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessService(ext);
                            }
                        }
                    }

                }

                await _systeamApplicationRepository.InsertOrUpdateAsync(ObjectMapper.Map<SystemApplication>(input));
                if (input.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.SYS, "SYS");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<PagedResultDto<SystemApplicationListDto>> GetAllSysteamApplicationList(GetSystemApplicationInput input)
        {
            try
            {
                var query = _systeamApplicationRepository.GetAllIncluding().
                    Include(x => x.Confidentiality).
                    Include(c => c.Integrity).
                    Include(y => y.LockThreatOrganization).
                    Include(e => e.Others).
                    Include(xx => xx.Availibility).
                    Include(x=>x.BusinessOwner)
                    .Include(xx => xx.BusinessUnit)                  
                    .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);

                var assetCount = await query.CountAsync();

                var systeamApplicationItems  = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var systeamApplicationListDto=ObjectMapper.Map<List<SystemApplicationListDto>>(systeamApplicationItems);

                return new PagedResultDto<SystemApplicationListDto>(
                   assetCount,
                   systeamApplicationListDto
                   );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveSysteamApplication(long assetId)
        {
            try
            {
                var systeamApplication  = await _systeamApplicationRepository.GetAll().Where(p => p.Id == assetId).Include(x => x.SelectedSysteamApplicationBusinessProcess).Include(x => x.SelectedSysteamApplicationITservices).Include(x => x.SelectedSystemApplicationServices).FirstOrDefaultAsync();
                if (systeamApplication.SelectedSysteamApplicationITservices.Count > 0)
                {
                    foreach (var item in systeamApplication.SelectedSysteamApplicationITservices)
                    {
                        await RemoveItService(item.Id);
                    }
                }

                if (systeamApplication.SelectedSysteamApplicationBusinessProcess.Count > 0)
                {
                    foreach (var item in systeamApplication.SelectedSysteamApplicationBusinessProcess)
                    {
                        await RemoveBusinessProcess(item.Id);
                    }
                }

                if (systeamApplication.SelectedSystemApplicationServices.Count > 0)
                {
                    foreach (var item in systeamApplication.SelectedSystemApplicationServices)
                    {
                        await RemoveBusinessService(item.Id);
                    }
                }
                await _systeamApplicationRepository.DeleteAsync(systeamApplication);
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
                var itservice = await _systeamApplicationITserviceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _systeamApplicationITserviceRepository.DeleteAsync(itservice);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveBusinessProcess(long id)
        {
            try
            {
                var employee = await _systeamApplicationBusinessProcessRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _systeamApplicationBusinessProcessRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveBusinessService(long id)
        {
            try
            {
                var employee = await _systemApplicationServiceRepository.FirstOrDefaultAsync(e => e.Id == id);

                await _systemApplicationServiceRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
