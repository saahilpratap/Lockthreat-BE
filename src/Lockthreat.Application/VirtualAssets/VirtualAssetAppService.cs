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
using Lockthreat.VirtualAssets.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lockthreat.HardwareAssets.Dto;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using Lockthreat.HardwareAssets;

namespace Lockthreat.VirtualAssets
{
public class VirtualAssetAppService : LockthreatAppServiceBase,IVirtualAssetAppService
    {
        private readonly IRepository<HardwareAsset, long> _hardwareAssetAppservice;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly IRepository<VirtualAsset, long> _virtualAssetAppservice ;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<VirtualAssetITservice, long> _virtualAssetItserviceRepository ;
        private readonly IRepository<VirtualAssetBusinessprocess, long> _virtualAssetBusinessprocessRepository;
        private readonly IRepository<VirtualAssetBusinessService, long> _virtualAssetBusinessServiceRepository;
        private readonly IRepository<ITService, long> _itservicesRepository;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<BusinessProcess, long> _businessProcessRepository;
        private readonly IRepository<BusinessService, long> _businessServicesRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        public VirtualAssetAppService(ICountriesAppservice countriesAppservice, 
            IRepository<LockThreatOrganization, long> organizationSetupRepository, 
            IRepository<VirtualAsset, long> virtualAssetAppservice,
            ICodeGeneratorCommonAppservice codegeneratorRepository,
            IRepository<VirtualAssetITservice, long> virtualAssetItserviceRepository,
            IRepository<ITService, long> itservicesRepository,
            IRepository<BusinessUnit, long> businessUnitRepository,
            IRepository<BusinessProcess, long> businessProcessRepository,
            IRepository<BusinessService, long> businessServicesRepository,
             IRepository<HardwareAsset, long> hardwareAssetAppservice,
            IRepository<VirtualAssetBusinessService, long> virtualAssetBusinessServiceRepository,
            IRepository<VirtualAssetBusinessprocess, long> virtualAssetBusinessprocessRepository,
            IRepository<Employees.Employee, long> employessRepository)
         {
            _countriesAppservice = countriesAppservice;
            _organizationSetupRepository = organizationSetupRepository;
            _virtualAssetAppservice = virtualAssetAppservice;
            _codegeneratorRepository = codegeneratorRepository;
            _virtualAssetItserviceRepository = virtualAssetItserviceRepository;
            _virtualAssetBusinessprocessRepository = virtualAssetBusinessprocessRepository;
            _virtualAssetBusinessServiceRepository = virtualAssetBusinessServiceRepository;
            _itservicesRepository = itservicesRepository;
            _businessUnitRepository = businessUnitRepository;
            _businessProcessRepository = businessProcessRepository;
            _businessServicesRepository = businessServicesRepository;
            _employessRepository = employessRepository;
            _hardwareAssetAppservice = hardwareAssetAppservice;
          }

        public async Task<VirtualAssetDto>GetAllVirtualAssetInfo(long? virtualAssetId )
        {
            try
            {
                var virtualAsset= new VirtualAssetDto();
                var virtualAssetById = new VirtualAsset();
                if (virtualAssetId > 0)
                {
                    virtualAssetById = await _virtualAssetAppservice.GetAll().FirstOrDefaultAsync(p => p.Id == virtualAssetId);
                    virtualAsset.SelectedVirtualAssetITservices = ObjectMapper.Map<List<VirtualAssetITserviceDto>>(await _virtualAssetItserviceRepository.GetAll().Where(p => p.VirtualAssetId == virtualAssetById.Id).ToListAsync());
                    virtualAsset.SelectedVirtualAssetBusinessprocess = ObjectMapper.Map<List<VirtualAssetBusinessprocessDto>>(await _virtualAssetBusinessprocessRepository.GetAll().Where(p => p.VirtualAssetId == virtualAssetById.Id).ToListAsync());
                    virtualAsset.SelectedVirtualAssetBusinessServices = ObjectMapper.Map<List<VirtualAssetBusinessServiceDto>>(await _virtualAssetBusinessServiceRepository.GetAll().Where(p => p.VirtualAssetId == virtualAssetById.Id).ToListAsync());
                }
                if (virtualAssetById.Id > 0)
                {
                    virtualAsset = ObjectMapper.Map<VirtualAssetDto>(virtualAssetById);
                }
                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                virtualAsset.EmployeesList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                virtualAsset.BusinessUnitGaurdians = ObjectMapper.Map<List<BusinessUnitGaurdianDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                virtualAsset.BusinessUnitOwners = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                virtualAsset.ITserviceLists = ObjectMapper.Map<List<ITserviceListDto>>(await _itservicesRepository.GetAll().ToListAsync());
                virtualAsset.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());               
                virtualAsset.BusinessProcess = ObjectMapper.Map<List<BusinessProcessDetailDto>>(await _businessProcessRepository.GetAll().ToListAsync());
                virtualAsset.BusinessServices = ObjectMapper.Map<List<BusinessServiceSDto>>(await _businessServicesRepository.GetAll().ToListAsync());
                virtualAsset.HardwareAssetList = ObjectMapper.Map<List<HardwareAsseDetailListDto>>(await _hardwareAssetAppservice.GetAll().ToListAsync());
                virtualAsset.ParentVirtualHostList = ObjectMapper.Map<List<ParentVirtualHostListDto>>(await _virtualAssetAppservice.GetAll().Where(x=>x.VirtualMachine==false).ToListAsync());
                virtualAsset.Confidentialitys = await _countriesAppservice.GetAllConfidentiality();
                virtualAsset.Otheres = await _countriesAppservice.GetAllOthers();
                virtualAsset.Integritys = await _countriesAppservice.GetAllIntergrity();
                virtualAsset.Availibilitys = await _countriesAppservice.GetAvailibility();
                return virtualAsset;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task CreateOrUpdateVirtualAsset(VirtualAssetDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.VirtualAssetId))
                {
                    input.VirtualAssetId = _codegeneratorRepository.GetNextId(LockthreatConsts.VAM, "VAM");
                }
                input.TenantId = AbpSession.TenantId;

                if (input.Id > 0)
                {
                    if (input.RemovedVirtualAssetITservice != null)
                    {
                        foreach (var unitId in input.RemovedVirtualAssetITservice)
                        {
                            bool exist = _virtualAssetItserviceRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemoveItService(unitId);
                            }
                        }
                    }

                    if (input.RemovedVirtualAssetBusinessprocess != null)
                    {
                        foreach (var ext in input.RemovedVirtualAssetBusinessprocess)
                        {
                            bool exist = _virtualAssetBusinessprocessRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessProcess(ext);
                            }
                        }
                    }

                    if (input.RemovedVirtualAssetBusinessServices != null)
                    {
                        foreach (var ext in input.RemovedVirtualAssetBusinessServices)
                        {
                            bool exist = _virtualAssetBusinessServiceRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessService(ext);
                            }
                        }
                    }

                }

                await _virtualAssetAppservice.InsertOrUpdateAsync(ObjectMapper.Map<VirtualAsset>(input));

                if (input.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.VAM, "VAM");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<PagedResultDto<VirtualAssetListDto>> GetAllVirtualAssetList (VirtualAssetInput input)
        {
            try
            {
                var query = _virtualAssetAppservice.GetAllIncluding().                                      
                    Include(y => y.LockThreatOrganization). 
                    Include(x=>x.HostedServerName).
                    Include(x=>x.BusinessUnit).
                    Include(x=>x.BusinessUnitGaurdian)
                    .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);

                var virtualassetCount  = await query.CountAsync();

                var virtualassetItems = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var virtualassetListDtos  = ObjectMapper.Map<List<VirtualAssetListDto>>(virtualassetItems);

                return new PagedResultDto<VirtualAssetListDto>(
                   virtualassetCount,
                   virtualassetListDtos
                   );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveVirtualAsset (long virtualAssetId )
        {
            try
            {
                var virtualAsset  = await _virtualAssetAppservice.GetAll().Where(p => p.Id == virtualAssetId).Include(x => x.SelectedVirtualAssetBusinessprocess).Include(x => x.SelectedVirtualAssetBusinessServices).Include(x => x.SelectedVirtualAssetITservices).FirstOrDefaultAsync();
                if (virtualAsset.SelectedVirtualAssetITservices.Count > 0)
                {
                    foreach (var item in virtualAsset.SelectedVirtualAssetITservices)
                    {
                        await RemoveItService(item.Id);
                    }
                }

                if (virtualAsset.SelectedVirtualAssetBusinessprocess.Count > 0)
                {
                    foreach (var item in virtualAsset.SelectedVirtualAssetBusinessprocess)
                    {
                        await RemoveBusinessProcess(item.Id);
                    }
                }

                if (virtualAsset.SelectedVirtualAssetBusinessServices.Count > 0)
                {
                    foreach (var item in virtualAsset.SelectedVirtualAssetBusinessServices)
                    {
                        await RemoveBusinessService(item.Id);
                    }
                }
                await _virtualAssetAppservice.DeleteAsync(virtualAsset);
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
                var itservice = await _virtualAssetItserviceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _virtualAssetItserviceRepository.DeleteAsync(itservice);
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
                var employee = await _virtualAssetBusinessprocessRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _virtualAssetBusinessprocessRepository.DeleteAsync(employee);
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
                var employee = await _virtualAssetBusinessServiceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _virtualAssetBusinessServiceRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
