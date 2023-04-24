using Abp.Domain.Repositories;
using Lockthreat.AssetInformations;
using Lockthreat.BusinessEntities;
using Lockthreat.Common;
using Lockthreat.ControlDesigns;
using Lockthreat.ControlOperatingTests;
using Lockthreat.Countries;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.Findings.Dto;
using Lockthreat.FindingsInformation;
using Lockthreat.HardwareAssets;
using Lockthreat.Incidents;
using Lockthreat.InternalControls;
using Lockthreat.ITServices;
using Lockthreat.OrganizationSetups;
using Lockthreat.RiskManagements;
using Lockthreat.StrategicObjectives;
using Lockthreat.SystemApplications;
using Lockthreat.Vendors;
using Lockthreat.VirtualAssets;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lockthreat.AssetInformations.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.VirtualAssets.Dto;
using Lockthreat.HardwareAssets.Dto;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.SystemApplications.Dto;
using Lockthreat.StrategicObjectives.Dto;
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Linq.Extensions;
using System.Reflection;
using Abp.Extensions;

namespace Lockthreat.Findings
{
  public  class FindingAppService : LockthreatAppServiceBase, IFindingAppService
   {
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<FacilitieDatacenter, long> _facilitieDatacenterRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly IRepository<Finding, long> _findingRepository;
        private readonly IRepository<FindingAssetInformation, long> _findingAssetInformationRepository;
        private readonly IRepository<FindingAuthoratativeSource, long> _findingAuthoratativeSourceRepository;
        private readonly IRepository<FindingBusinessUnit, long> _findingBusinessUnitRepository;
        private readonly IRepository<FindingControlDesign, long> _findingControlDesignRepository;
        private readonly IRepository<FindingControlOperating, long> _findingControlOperatingRepository;
        private readonly IRepository<FindingFacilitieDatacenter, long> _findingFacilitieDatacenterRepository;
        private readonly IRepository<FindingHardwareAsset, long> _findingHardwareAssetRepository;
        private readonly IRepository<FindingInternalControl, long> _findingInternalControlRepository;
        private readonly IRepository<FindingOrganization, long> _findingOrganizationRepository;
        private readonly IRepository<FindingRiskRegister, long> _findingRiskRegisterRepository;
        private readonly IRepository<FindingStrategicObjective, long> _findingStrategicObjectiveRepository;
        private readonly IRepository<FindingSystemsApplication, long> _findingSystemsApplicationRepository;
        private readonly IRepository<FindingVendor, long> _findingVendorRepository;
        private readonly IRepository<FindingVirtualHost, long> _findingVirtualHostRepository;
        private readonly IRepository<FindingVirtualMachine, long> _findingVirtualMachineRepository;
        private readonly IRepository<FindingIncident, long> _findingFindingIncidentRepository;
        private readonly IRepository<AssetInformation, long> _assetInformationRepository;
        private readonly IRepository<SystemApplication, long> _systemApplicationRepository;
        private readonly IRepository<HardwareAsset, long> _hardwareAssetRepository;
        private readonly IRepository<StrategicObjective, long> _strategicObjectiveRepository;
        private readonly IRepository<VirtualAsset, long> _virtualAssetRepository;
        private readonly IRepository<Vendor, long> _vendorRepository;
        private readonly IRepository<RiskManagement, long> _riskManagementRepository;
        private readonly IRepository<ControlDesign, long> _controlDesignRepository;
        private readonly IRepository<ControlOperatingTest, long> _controlOperatingTestRepository;
        private readonly IRepository<InternalControl, long> _internalControlRepository;
        private readonly IRepository<Incident, long> _incidentRepository;
        private readonly IRepository<AuthoratativeDocuments.AuthoratativeDocument, long> _authorativeDocumentRepository;
        public FindingAppService(
            IRepository<FacilitieDatacenter, long> facilitieDatacenterRepository,
            IRepository<AuthoratativeDocuments.AuthoratativeDocument, long> authorativeDocumentRepository,
            IRepository<FindingIncident, long> findingFindingIncidentRepository,
            IRepository<Finding, long> findingRepository,
            IRepository<FindingAssetInformation, long> findingAssetInformationRepository,
            IRepository<FindingAuthoratativeSource, long> findingAuthoratativeSourceRepository,
            IRepository<FindingBusinessUnit, long> findingBusinessUnitRepository,
            IRepository<FindingControlDesign, long> findingControlDesignRepository,
            IRepository<FindingControlOperating, long> findingControlOperatingRepository,
            IRepository<FindingFacilitieDatacenter, long> findingFacilitieDatacenterRepository,
            IRepository<FindingHardwareAsset, long> findingHardwareAssetRepository,
            IRepository<FindingInternalControl, long> findingInternalControlRepository,
            IRepository<FindingOrganization, long> findingOrganizationRepository,
            IRepository<FindingRiskRegister, long> findingRiskRegisterRepository,
            IRepository<FindingStrategicObjective, long> findingStrategicObjectiveRepository,
            IRepository<FindingSystemsApplication, long> findingSystemsApplicationRepository,
            IRepository<FindingVendor, long> findingVendorRepository,
            IRepository<FindingVirtualHost, long> findingVirtualHostRepository,
            IRepository<AssetInformation, long> assetInformationRepository,
            IRepository<FindingVirtualMachine, long> findingVirtualMachineRepository,
           ICountriesAppservice countriesAppservice,
           IRepository<LockThreatOrganization, long> organizationSetupRepository,
           IRepository<Employees.Employee, long> employessRepository,
           IRepository<BusinessUnit, long> businessUnitRepository,
           ICodeGeneratorCommonAppservice codegeneratorRepository,
           IRepository<Incident, long> incidentRepository,
           IRepository<InternalControl, long> internalControlRepository,
           IRepository<ControlOperatingTest, long> controlOperatingTestRepository,
           IRepository<ControlDesign, long> controlDesignRepository,
           IRepository<RiskManagement, long> riskManagementRepository,
           IRepository<Vendor, long> vendorRepository,
           IRepository<VirtualAsset, long> virtualAssetRepository,
           IRepository<StrategicObjective, long> strategicObjectiveRepository,
           IRepository<HardwareAsset, long> hardwareAssetRepository,
           IRepository<SystemApplication, long> systemApplicationRepository
         )
        {
            _facilitieDatacenterRepository = facilitieDatacenterRepository;
            _authorativeDocumentRepository = authorativeDocumentRepository;
            _findingFindingIncidentRepository = findingFindingIncidentRepository;
            _findingControlOperatingRepository = findingControlOperatingRepository;
            _findingControlDesignRepository = findingControlDesignRepository;
            _findingBusinessUnitRepository = findingBusinessUnitRepository;
            _findingAuthoratativeSourceRepository = findingAuthoratativeSourceRepository;
            _findingAssetInformationRepository = findingAssetInformationRepository;
            _findingFacilitieDatacenterRepository = findingFacilitieDatacenterRepository;
            _findingHardwareAssetRepository = findingHardwareAssetRepository;
            _findingInternalControlRepository = findingInternalControlRepository;
            _findingOrganizationRepository = findingOrganizationRepository;
            _findingRiskRegisterRepository = findingRiskRegisterRepository;
            _findingStrategicObjectiveRepository = findingStrategicObjectiveRepository;
            _findingSystemsApplicationRepository = findingSystemsApplicationRepository;
            _findingRepository = findingRepository;
            _findingVendorRepository = findingVendorRepository;
            _findingVirtualHostRepository = findingVirtualHostRepository;
            _findingVirtualMachineRepository = findingVirtualMachineRepository;
            _internalControlRepository = internalControlRepository;
            _controlOperatingTestRepository = controlOperatingTestRepository;
            _controlDesignRepository = controlDesignRepository;
            _riskManagementRepository = riskManagementRepository;
            _vendorRepository = vendorRepository;
            _virtualAssetRepository = virtualAssetRepository;
            _strategicObjectiveRepository = strategicObjectiveRepository;
            _hardwareAssetRepository = hardwareAssetRepository;
            _systemApplicationRepository = systemApplicationRepository;
            _incidentRepository = incidentRepository;
            _countriesAppservice = countriesAppservice;
            _organizationSetupRepository = organizationSetupRepository;
            _codegeneratorRepository = codegeneratorRepository;
            _assetInformationRepository = assetInformationRepository;
            _employessRepository = employessRepository;
            _businessUnitRepository = businessUnitRepository;
        }


        public async Task<PagedResultDto<FindingListDto>> GetAllFindingList (FindingInputDto input)
        {
            try
            {
                var query = _findingRepository.GetAllIncluding().
                    Include(x => x.FindingCoordinator).
                    Include(c => c.FindingManager).
                    Include(y => y.FindingOwner).
                    Include(e => e.FindingStatus).
                    Include(f => f.Category).
                    Include(g => g.Assigned).
                    Include(xx => xx.Classification)
                   .WhereIf(!input.Filter.IsNullOrWhiteSpace(), u => u.FindingId.Contains(input.Filter.Trim()) || u.FindingDetails.Contains(input.Filter.Trim()) ||
                        u.FindingCoordinator.Name.Contains(input.Filter.Trim()) ||                        
                        u.Classification.Value.Contains(input.Filter.Trim()));
                var findingCount = await query.CountAsync();

                var findingItems  = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var findingListDtos = ObjectMapper.Map<List<FindingListDto>>(findingItems);

                return new PagedResultDto<FindingListDto>(
                   findingCount,
                   findingListDtos
                   );
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<FindingInfoDto> GetAllfindingInfo (long? findingId)
        {
            try
            {
                var finding = new FindingInfoDto();
                var findingById = new Finding();
                if (findingId > 0)
                {
                    findingById = await _findingRepository.GetAll().FirstOrDefaultAsync(p => p.Id == findingId);
                }

                if (findingById.Id > 0)
                {
                    finding = ObjectMapper.Map<FindingInfoDto>(findingById);
                    finding.SelectedFindingAssetInformations = ObjectMapper.Map<List<FindingAssetInformationDto>>(await _findingAssetInformationRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingAuthoratativeSources = ObjectMapper.Map<List<FindingAuthoratativeSourceDto>>(await _findingAuthoratativeSourceRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingBusinessUnits = ObjectMapper.Map<List<FindingBusinessUnitDto>>(await _findingBusinessUnitRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingControlDesigns = ObjectMapper.Map<List<FindingControlDesignDto>>(await _findingControlDesignRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingControlOperatings = ObjectMapper.Map<List<FindingControlOperatingDto>>(await _findingControlOperatingRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingFacilitieDatacenters = ObjectMapper.Map<List<FindingFacilitieDatacenterDto>>(await _findingFacilitieDatacenterRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingSystemsApplications = ObjectMapper.Map<List<FindingSystemsApplicationDto>>(await _findingSystemsApplicationRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingVendors = ObjectMapper.Map<List<FindingVendorDto>>(await _findingVendorRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingVirtualHosts = ObjectMapper.Map<List<FindingVirtualHostDto>>(await _findingVirtualHostRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingVirtualMachines = ObjectMapper.Map<List<FindingVirtualMachineDto>>(await _findingVirtualMachineRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingHardwareAssets = ObjectMapper.Map<List<FindingHardwareAssetDto>>(await _findingHardwareAssetRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingIncidents = ObjectMapper.Map<List<FindingIncidentDto>>(await _findingFindingIncidentRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingInternalControls = ObjectMapper.Map<List<FindingInternalControlDto>>(await _findingInternalControlRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingOrganizations = ObjectMapper.Map<List<FindingOrganizationDto>>(await _findingOrganizationRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingRiskRegisters = ObjectMapper.Map<List<FindingRiskRegisterDto>>(await _findingRiskRegisterRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                    finding.SelectedFindingStrategicObjectives = ObjectMapper.Map<List<FindingStrategicObjectiveDto>>(await _findingStrategicObjectiveRepository.GetAll().Where(p => p.FindingId == findingById.Id).ToListAsync());
                }

                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                finding.FindingCoordinatorList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                finding.FindingManagerList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                finding.FindingOwnerList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);               
                finding.ReviewesList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                finding.AssignedList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                finding.BusinessUnitList = ObjectMapper.Map<List<BusinessUnitGaurdianDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                finding.HardwareAssetList = ObjectMapper.Map<List<HardwareAsseDetailListDto>>(await _hardwareAssetRepository.GetAll().ToListAsync());
                finding.CompanyList = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                finding.ControlDesignList = ObjectMapper.Map<List<ControlDesignListDto>>(await _controlDesignRepository.GetAll().ToListAsync());
                finding.ControlOperatingList = ObjectMapper.Map<List<ControlOperatingListDto>>(await _controlOperatingTestRepository.GetAll().ToListAsync());
                finding.FacilitieDatacenterList = ObjectMapper.Map<List<FacilitieDatacenterListDto>>(await _facilitieDatacenterRepository.GetAll().ToListAsync());
                finding.AssetInformationList = ObjectMapper.Map<List<AssetInformationListDto>>(await _assetInformationRepository.GetAll().ToListAsync());
                finding.AuthoritativeSourceList = ObjectMapper.Map<List<ProgramAuthoritativeDocumentsDto>>(await _authorativeDocumentRepository.GetAll().ToListAsync());
                finding.InternalControlList = ObjectMapper.Map<List<InternalControlListDto>>(await _internalControlRepository.GetAll().ToListAsync());
                finding.VirtualHostList = ObjectMapper.Map<List<VirtualListDto>>(await _virtualAssetRepository.GetAll().ToListAsync());
                finding.VirtualMachineList = ObjectMapper.Map<List<VirtualListDto>>(await _virtualAssetRepository.GetAll().Where(x => x.VirtualMachine == false).ToListAsync());
                finding.SytemApplicationList = ObjectMapper.Map<List<SytemApplicationDto>>(await _systemApplicationRepository.GetAll().ToListAsync());
                finding.RiskRegisterList = ObjectMapper.Map<List<RiskRegisterListDto>>(await _riskManagementRepository.GetAll().ToListAsync());
                finding.StrategicObjectiveList = ObjectMapper.Map<List<StrategicObjectivesDto>>(await _strategicObjectiveRepository.GetAll().ToListAsync());
                finding.VendorList = ObjectMapper.Map<List<VendorListDto>>(await _vendorRepository.GetAll().ToListAsync());
                finding.FindingIncidentList = ObjectMapper.Map<List<FindingIncidentListDto>>(await _incidentRepository.GetAll().ToListAsync());
                finding.CategoryList = await _countriesAppservice.GetAllOthers();
                finding.FindingStatusList = await _countriesAppservice.GetAllIntergrity();
                finding.RankingList = await _countriesAppservice.GetAvailibility();
                finding.ClassificationList = await _countriesAppservice.GetMeetingClassification();
                finding.ActionLsit = await _countriesAppservice.GetAssetType();
                finding.Responses = await _countriesAppservice.GetAssetCategorys();

                return finding;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task CreateOrUpdateFinding (FindingInfoDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.FindingId))
                {
                    input.FindingId = _codegeneratorRepository.GetNextId(LockthreatConsts.FID, "FID");
                }

                input.TenantId = AbpSession.TenantId;

                if (input.Id > 0)
                {
                    var contract = await _findingRepository.
                        GetAll().
                        Include(x => x.SelectedFindingAssetInformations).
                        Include(x => x.SelectedFindingAuthoratativeSources).
                        Include(x => x.SelectedFindingBusinessUnits).
                        Include(x => x.SelectedFindingControlDesigns).
                        Include(x => x.SelectedFindingControlOperatings).
                        Include(x => x.SelectedFindingFacilitieDatacenters).
                        Include(x => x.SelectedFindingHardwareAssets).
                        Include(x => x.SelectedFindingIncidents).
                        Include(x => x.SelectedFindingInternalControls).
                        Include(x => x.SelectedFindingOrganizations).
                        Include(x => x.SelectedFindingRiskRegisters).
                        Include(x => x.SelectedFindingSystemsApplications).
                        Include(x => x.SelectedFindingStrategicObjectives).
                        Include(x => x.SelectedFindingVendors).
                        Include(x => x.SelectedFindingVirtualHosts).
                        Include(x => x.SelectedFindingVirtualMachines).                      
                        FirstOrDefaultAsync(x => x.Id == input.Id);
                    await _findingAssetInformationRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingAuthoratativeSourceRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingBusinessUnitRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingControlDesignRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingControlOperatingRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingFacilitieDatacenterRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingFindingIncidentRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingHardwareAssetRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingInternalControlRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingOrganizationRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingRiskRegisterRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingStrategicObjectiveRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingSystemsApplicationRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingVendorRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingVirtualHostRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    await _findingVirtualMachineRepository.HardDeleteAsync(r => r.FindingId == input.Id);
                    ObjectMapper.Map(input, contract);
                }
               
                if (input.Id == 0)
                {
                    await _findingRepository.InsertOrUpdateAsync(ObjectMapper.Map<Finding>(input));
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.FID, "FID");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task RemoveFinding(long findingId )
        {
            try
            {
                var finding  = await _findingRepository.GetAll().Include(x => x.SelectedFindingAssetInformations).
                        Include(x => x.SelectedFindingAuthoratativeSources).
                        Include(x => x.SelectedFindingBusinessUnits).
                        Include(x => x.SelectedFindingControlDesigns).
                        Include(x => x.SelectedFindingControlOperatings).
                        Include(x => x.SelectedFindingFacilitieDatacenters).
                        Include(x => x.SelectedFindingHardwareAssets).
                        Include(x => x.SelectedFindingIncidents).
                        Include(x => x.SelectedFindingInternalControls).
                        Include(x => x.SelectedFindingOrganizations).
                        Include(x => x.SelectedFindingRiskRegisters).
                        Include(x => x.SelectedFindingSystemsApplications).
                        Include(x => x.SelectedFindingStrategicObjectives).
                        Include(x => x.SelectedFindingVendors).
                        Include(x => x.SelectedFindingVirtualHosts).
                        Include(x => x.SelectedFindingVirtualMachines).
                        FirstOrDefaultAsync(x => x.Id == findingId);
                await _findingAssetInformationRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingAuthoratativeSourceRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingBusinessUnitRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingControlDesignRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingControlOperatingRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingFacilitieDatacenterRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingFindingIncidentRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingHardwareAssetRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingInternalControlRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingOrganizationRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingRiskRegisterRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingStrategicObjectiveRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingSystemsApplicationRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingVendorRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingVirtualHostRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingVirtualMachineRepository.HardDeleteAsync(r => r.FindingId == findingId);
                await _findingRepository.DeleteAsync(finding);

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
