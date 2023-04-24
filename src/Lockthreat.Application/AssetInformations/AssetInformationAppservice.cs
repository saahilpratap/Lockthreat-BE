using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Lockthreat.AssetInformations.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.OrganizationSetups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessProcesses;
using Lockthreat.BusinessServices;
using Lockthreat.ITServices;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.BusinessProcesses.Dto;

namespace Lockthreat.AssetInformations
{
   public class AssetInformationAppservice : LockthreatAppServiceBase
    {

        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;       
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<AssetInformation, long> _assetInformationRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly IRepository<AssetInformationBusinessprocess, long> _assetInformationBusinessprocessRepository;
        private readonly IRepository<AssetInformationBusinessService, long> _assetInformationBusinessServiceRepository;
        private readonly IRepository<AssetInformationITservice, long> _assetInformationITserviceRepository ;
        private readonly IRepository<ITService, long> _itservicesRepository;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<BusinessProcess, long> _businessProcessRepository;
        private readonly IRepository<BusinessService, long> _businessServicesRepository;
        public AssetInformationAppservice(
           ICountriesAppservice countriesAppservice,
           IRepository<LockThreatOrganization, long> organizationSetupRepository,
           IRepository<Employees.Employee, long> employessRepository, IRepository<AssetInformationBusinessprocess, long> assetInformationBusinessprocessRepository,
           IRepository<AssetInformationBusinessService, long> assetInformationBusinessServiceRepository,
           IRepository<AssetInformationITservice, long> assetInformationITserviceRepository,
            IRepository<BusinessUnit, long> businessUnitRepository,
            IRepository<BusinessProcess, long> businessProcessRepository,
            IRepository<BusinessService, long> businessServicesRepository,
             IRepository<ITService, long> itservicesRepository,
           ICodeGeneratorCommonAppservice codegeneratorRepository, IRepository<AssetInformation, long> assetInformationRepository
           )
        {
            _countriesAppservice = countriesAppservice;
            _organizationSetupRepository = organizationSetupRepository;            
            _codegeneratorRepository = codegeneratorRepository;
            _assetInformationRepository = assetInformationRepository;
            _employessRepository = employessRepository;
            _itservicesRepository = itservicesRepository;
            _businessUnitRepository = businessUnitRepository;
            _businessProcessRepository = businessProcessRepository;
            _businessServicesRepository = businessServicesRepository;
            _assetInformationBusinessprocessRepository = assetInformationBusinessprocessRepository;
            _assetInformationBusinessServiceRepository = assetInformationBusinessServiceRepository;
            _assetInformationITserviceRepository = assetInformationITserviceRepository;
        }

        public async Task<GetAssetInformationDto> GetAllAssetInformationInfo (long? assetId )
        {
            try
            {
                var assetInformation  = new GetAssetInformationDto();
                var assetInformationById = new AssetInformation();
                if (assetId > 0)
                {
                    assetInformationById = await _assetInformationRepository.GetAll().FirstOrDefaultAsync(p => p.Id == assetId);
                }

                if (assetInformationById.Id > 0)
                {
                    assetInformation = ObjectMapper.Map<GetAssetInformationDto>(assetInformationById);
                    assetInformation.SelectedAssetInformationITservices = ObjectMapper.Map<List<AssetInformationITserviceDto>>(await _assetInformationITserviceRepository.GetAll().Where(p => p.AssetInformationId == assetInformationById.Id).ToListAsync());
                    assetInformation.SelectedAssetInformationBusinessprocess = ObjectMapper.Map<List<AssetInformationBusinessprocessDto>>(await _assetInformationBusinessprocessRepository.GetAll().Where(p => p.AssetInformationId == assetInformationById.Id).ToListAsync());
                    assetInformation.SelectedAssetInformationBusinessServices = ObjectMapper.Map<List<AssetInformationBusinessServiceDto>>(await _assetInformationBusinessServiceRepository.GetAll().Where(p => p.AssetInformationId == assetInformationById.Id).ToListAsync());                    
                }
                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                assetInformation.EmployeesList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                assetInformation.BusinessUnitGaurdians = ObjectMapper.Map<List<BusinessUnitGaurdianDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                assetInformation.BusinessUnitOwners = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                assetInformation.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                assetInformation.Confidentialitys = await _countriesAppservice.GetAllConfidentiality();
                assetInformation.Otheres = await _countriesAppservice.GetAllOthers();
                assetInformation.Integritys = await _countriesAppservice.GetAllIntergrity();
                assetInformation.Availibilitys = await _countriesAppservice.GetAvailibility();
                assetInformation.Countries = await _countriesAppservice.GetAll();
                assetInformation.AssetTypes = await _countriesAppservice.GetAssetType();
                assetInformation.AssetCategorys = await _countriesAppservice.GetAssetCategorys();
                assetInformation.AssetLabels = await _countriesAppservice.GetAssetLabels();
                assetInformation.ITserviceLists = ObjectMapper.Map<List<ITserviceListDto>>(await _itservicesRepository.GetAll().ToListAsync());
                assetInformation.BusinessProcess = ObjectMapper.Map<List<BusinessProcessDetailDto>>(await _businessProcessRepository.GetAll().ToListAsync());
                assetInformation.BusinessServices = ObjectMapper.Map<List<BusinessServiceSDto>>(await _businessServicesRepository.GetAll().ToListAsync());
                return assetInformation;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task CreateOrUpdateAssetinformation (GetAssetInformationDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.AssetId))
                {
                    input.AssetId = _codegeneratorRepository.GetNextId(LockthreatConsts.AST, "AST");
                }
                input.TenantId = AbpSession.TenantId;
                await _assetInformationRepository.InsertOrUpdateAsync(ObjectMapper.Map<AssetInformation>(input));
                if (input.Id > 0)
                {
                    if (input.RemovedAssetInformationITservice != null)
                    {
                        foreach (var unitId in input.RemovedAssetInformationITservice)
                        {
                            bool exist = _assetInformationITserviceRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemoveItService(unitId);
                            }
                        }
                    }

                    if (input.RemovedAssetInformationBusinessprocess != null)
                    {
                        foreach (var ext in input.RemovedAssetInformationBusinessprocess)
                        {
                            bool exist = _assetInformationBusinessprocessRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessProcess(ext);
                            }
                        }
                    }

                    if (input.RemovedAssetInformationBusinessService != null)
                    {
                        foreach (var ext in input.RemovedAssetInformationBusinessService)
                        {
                            bool exist = _assetInformationBusinessServiceRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessService(ext);
                            }
                        }
                    }

                }


                if (input.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.AST, "AST");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<PagedResultDto<GetAssetInformationListDto>> GetAllAssetinformationList (AssetInformationInput input)
        {
            try
            {
                var query = _assetInformationRepository.GetAllIncluding().
                    Include(x => x.Confidentiality).
                    Include(c => c.Integrity).
                    Include(y => y.LockThreatOrganization).
                    Include(e => e.Other).                     
                    Include(xx => xx.Availibility)
                    .Include(xx=>xx.Employee).
                     Include(xx=>xx.AssetType).
                     Include(x=>x.AssetCategory)
                    .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);

                var assetCount = await query.CountAsync();

                var hardwareassetItems = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var assetListDtos = ObjectMapper.Map<List<GetAssetInformationListDto>>(hardwareassetItems);

                return new PagedResultDto<GetAssetInformationListDto>(
                   assetCount,
                   assetListDtos.OrderByDescending(x => x.Id).ToList()
                   );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveAssetInformation(long assetId)
        {
            try
            {
                var assetInformation  = await _assetInformationRepository.GetAll().Where(p => p.Id == assetId).Include(x=>x.SelectedAssetInformationBusinessprocess).Include(x=>x.SelectedAssetInformationBusinessServices).Include(x=>x.SelectedAssetInformationITservices).FirstOrDefaultAsync();
                if (assetInformation.SelectedAssetInformationITservices.Count > 0)
                {
                    foreach (var item in assetInformation.SelectedAssetInformationITservices)
                    {
                        await RemoveItService(item.Id);
                    }
                }

                if (assetInformation.SelectedAssetInformationBusinessprocess.Count > 0)
                {
                    foreach (var item in assetInformation.SelectedAssetInformationBusinessprocess)
                    {
                        await RemoveBusinessProcess(item.Id);
                    }
                }

                if (assetInformation.SelectedAssetInformationBusinessServices.Count > 0)
                {
                    foreach (var item in assetInformation.SelectedAssetInformationBusinessServices)
                    {
                        await RemoveBusinessService(item.Id);
                    }
                }
                await _assetInformationRepository.DeleteAsync(assetInformation);
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
                var itservice = await _assetInformationITserviceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _assetInformationITserviceRepository.DeleteAsync(itservice);
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
                var employee = await _assetInformationBusinessprocessRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _assetInformationBusinessprocessRepository.DeleteAsync(employee);
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
                var employee = await _assetInformationBusinessServiceRepository.FirstOrDefaultAsync(e => e.Id == id);

                await _assetInformationBusinessServiceRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
