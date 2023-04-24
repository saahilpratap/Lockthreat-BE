using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.HardwareAssets.Dto;
using Lockthreat.OrganizationSetups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.ITServices;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessProcesses;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices;

namespace Lockthreat.HardwareAssets
{
 public class HardWareAssetAppService : LockthreatAppServiceBase, IHardwareAssetAppService
    {
         private readonly ICountriesAppservice _countriesAppservice;
         private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
         private readonly IRepository<HardwareAsset, long> _hardwareAssetAppservice;
         private readonly IRepository<FacilitieDatacenter, long> _facilitiesDataCenterRepository;
         private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
         private readonly IRepository<HardwareAssetITservice, long> _hardwareAssetItserviceRepository;
         private readonly IRepository<HardwareAssetBusinessprocess, long> _hardwareAssetBusinessprocessRepository;
         private readonly IRepository<HardwareAssetBusinessService, long> _hardwareAssetBusinessServiceRepository;
         private readonly IRepository<ITService, long> _itservicesRepository;
         private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
         private readonly IRepository<BusinessProcess, long> _businessProcessRepository;
         private readonly IRepository<BusinessService, long> _businessServicesRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;

        public HardWareAssetAppService(
            ICountriesAppservice countriesAppservice, IRepository<LockThreatOrganization, long> organizationSetupRepository,
            IRepository<HardwareAsset, long> hardwareAssetAppservice, IRepository<FacilitieDatacenter, long> facilitiesDataCenterRepository,
            ICodeGeneratorCommonAppservice codegeneratorRepository , IRepository<HardwareAssetITservice, long> hardwareAssetItservicerepository,
            IRepository<HardwareAssetBusinessprocess, long> hardwareAssetBusinessprocessRepository,
            IRepository<HardwareAssetBusinessService, long> hardwareAssetBusinessServiceRepository,
            IRepository<Employees.Employee, long> employessRepository,
            IRepository<ITService, long> itservicesRepository,
            IRepository<BusinessUnit, long> businessUnitRepository,
            IRepository<BusinessProcess, long> businessProcessRepository,
            IRepository<BusinessService, long> businessServicesRepository
            )
           {
            _employessRepository = employessRepository;
            _itservicesRepository = itservicesRepository;
            _businessUnitRepository = businessUnitRepository;
            _businessProcessRepository = businessProcessRepository;
            _countriesAppservice = countriesAppservice;
            _organizationSetupRepository = organizationSetupRepository;
            _hardwareAssetAppservice = hardwareAssetAppservice;
            _facilitiesDataCenterRepository = facilitiesDataCenterRepository;
            _codegeneratorRepository = codegeneratorRepository;
            _hardwareAssetItserviceRepository = hardwareAssetItservicerepository;
            _hardwareAssetBusinessprocessRepository = hardwareAssetBusinessprocessRepository;
            _hardwareAssetBusinessServiceRepository = hardwareAssetBusinessServiceRepository;
            _businessServicesRepository = businessServicesRepository;
          }

        public async Task<HardwareAssetDto> GetAllhardwareAssetInfo (long? hardwareAssetId )
        {
            try
            {
                var hardWareAsset=  new HardwareAssetDto();
                var hardWareAssetById  = new HardwareAsset();
                if (hardwareAssetId > 0)
                {
                    hardWareAssetById = await _hardwareAssetAppservice.GetAll().FirstOrDefaultAsync(p => p.Id == hardwareAssetId);
                    hardWareAsset.SelectedHardwareAssetITservices = ObjectMapper.Map<List<HardwareAssetITserviceDto>>(await _hardwareAssetItserviceRepository.GetAll().Where(p => p.HardwareAssetId == hardWareAssetById.Id).ToListAsync());
                    hardWareAsset.SelectedHardwareAssetBusinessprocess = ObjectMapper.Map<List<HardwareAssetBusinessprocessDto>>(await _hardwareAssetBusinessprocessRepository.GetAll().Where(p => p.HardwareAssetId == hardWareAssetById.Id).ToListAsync());
                    hardWareAsset.SelectedHardwareAssetBusinessServices = ObjectMapper.Map<List<HardwareAssetBusinessServiceDto>>(await _hardwareAssetBusinessServiceRepository.GetAll().Where(p => p.HardwareAssetId == hardWareAssetById.Id).ToListAsync());
                }
                if (hardWareAssetById.Id > 0)
                {
                    hardWareAsset = ObjectMapper.Map<HardwareAssetDto>(hardWareAssetById);
                   
                }
                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                hardWareAsset.EmployeesList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                hardWareAsset.BusinessUnitGaurdians = ObjectMapper.Map<List<BusinessUnitGaurdianDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                hardWareAsset.BusinessUnitOwners = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                hardWareAsset.ITserviceLists = ObjectMapper.Map<List<ITserviceListDto>>(await _itservicesRepository.GetAll().ToListAsync());
                hardWareAsset.LocationLists = ObjectMapper.Map<List<FacilitieDatacenterListDto>>(await _facilitiesDataCenterRepository.GetAll().ToListAsync()); 
                hardWareAsset.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                hardWareAsset.Confidentialitys = await _countriesAppservice.GetAllConfidentiality();
                hardWareAsset.Otheres = await _countriesAppservice.GetAllOthers();
                hardWareAsset.Integritys = await _countriesAppservice.GetAllIntergrity();
                hardWareAsset.Availibilitys = await _countriesAppservice.GetAvailibility();
                hardWareAsset.BusinessProcess = ObjectMapper.Map<List<BusinessProcessDetailDto>>(await _businessProcessRepository.GetAll().ToListAsync());
                hardWareAsset.BusinessServices = ObjectMapper.Map<List<BusinessServiceSDto>>(await _businessServicesRepository.GetAll().ToListAsync());
                return hardWareAsset;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task CreateOrUpdateHardwareAsset (HardwareAssetDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.AssetId))
                {
                    input.AssetId = _codegeneratorRepository.GetNextId(LockthreatConsts.HAR, "HAR");
                }
                input.TenantId = AbpSession.TenantId;

                if (input.Id > 0)
                {
                    if (input.RemovedHardwareAssetITservice != null)
                    {
                        foreach (var unitId in input.RemovedHardwareAssetITservice)
                        {
                            bool exist = _hardwareAssetItserviceRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemoveItService(unitId);
                            }
                        }
                    }

                    if (input.RemovedHardwareAssetBusinessprocess != null)
                    {
                        foreach (var ext in input.RemovedHardwareAssetBusinessprocess)
                        {
                            bool exist = _hardwareAssetBusinessprocessRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessProcess(ext);
                            }
                        }
                    }

                    if (input.RemovedHardwareAssetBusinessService != null)
                    {
                        foreach (var ext in input.RemovedHardwareAssetBusinessService)
                        {
                            bool exist = _hardwareAssetBusinessServiceRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessService(ext);
                            }
                        }
                    }

                }

                await _hardwareAssetAppservice.InsertOrUpdateAsync(ObjectMapper.Map<HardwareAsset>(input));

                if (input.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.HAR, "HAR");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<PagedResultDto<HardwareAssetListDto>> GetAllHardwareAssetList (GetHardwareAssetInput input)
        {
            try
            {
                var query = _hardwareAssetAppservice.GetAllIncluding().
                    Include(x => x.Confidentiality).
                    Include(c => c.Integrity).
                    Include(y => y.LockThreatOrganization).
                    Include(e => e.Others).                   
                    Include(g => g.Locations).
                    Include(xx => xx.Availibility)                  
                   .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);

                var hardwareassetCount  = await query.CountAsync();

                var hardwareassetItems  = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var hardwareassetListDtos = ObjectMapper.Map<List<HardwareAssetListDto>>(hardwareassetItems);

                return new PagedResultDto<HardwareAssetListDto>(
                   hardwareassetCount,
                   hardwareassetListDtos
                   );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemovehardwareAsset(long hardwareAssetId )
        {
            try
            {
                var hardwareAsset  = await _hardwareAssetAppservice.GetAll().Where(p => p.Id == hardwareAssetId).Include(x=>x.SelectedHardwareAssetBusinessProcess).Include(x=>x.SelectedHardwareAssetBusinessServices).Include(x=>x.SelectedHardwareAssetITServices).FirstOrDefaultAsync();
                if (hardwareAsset.SelectedHardwareAssetITServices.Count > 0)
                {
                    foreach (var item in hardwareAsset.SelectedHardwareAssetITServices)
                    {
                        await RemoveItService(item.Id);
                    }
                }

                if (hardwareAsset.SelectedHardwareAssetBusinessProcess.Count > 0)
                {
                    foreach (var item in hardwareAsset.SelectedHardwareAssetBusinessProcess)
                    {
                        await RemoveBusinessProcess(item.Id);
                    }
                }

                if (hardwareAsset.SelectedHardwareAssetBusinessServices.Count > 0)
                {
                    foreach (var item in hardwareAsset.SelectedHardwareAssetBusinessServices)
                    {
                        await RemoveBusinessService(item.Id);
                    }
                }
                await _hardwareAssetAppservice.DeleteAsync(hardwareAsset);
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
                var itservice = await _hardwareAssetItserviceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _hardwareAssetItserviceRepository.DeleteAsync(itservice);
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
                var employee = await _hardwareAssetBusinessprocessRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _hardwareAssetBusinessprocessRepository.DeleteAsync(employee);
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
                var employee = await _hardwareAssetBusinessServiceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _hardwareAssetBusinessServiceRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
