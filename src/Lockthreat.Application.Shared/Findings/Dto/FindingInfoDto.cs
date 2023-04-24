using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.AssetInformations.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.HardwareAssets.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.StrategicObjectives.Dto;
using Lockthreat.SystemApplications.Dto;
using Lockthreat.VirtualAssets.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Findings.Dto
{
  public  class FindingInfoDto : FullAuditedEntity<long>
    {
        public FindingInfoDto()
        {
            CategoryList = new List<GetDynamicValueDto>();
            FindingStatusList = new List<GetDynamicValueDto>();
            RankingList = new List<GetDynamicValueDto>();
            ClassificationList = new List<GetDynamicValueDto>();
            FindingManagerList = new List<BusinessServiceOwner>();
            FindingCoordinatorList = new List<BusinessServiceOwner>();
            FindingOwnerList = new List<BusinessServiceOwner>();
            ActionLsit = new List<GetDynamicValueDto>();
            ReviewesList = new List<BusinessServiceOwner>();
            Responses = new List<GetDynamicValueDto>();
            AssignedList = new List<BusinessServiceOwner>();
            AuthoritativeSourceList = new List<ProgramAuthoritativeDocumentsDto>();
            AssetInformationList = new List<AssetInformationListDto>();
            BusinessUnitList = new List<BusinessUnitGaurdianDto>();
            CompanyList = new List<GetOrganizationDto>();
            ControlDesignList = new List<ControlDesignListDto>();
            ControlOperatingList = new List<ControlOperatingListDto>();
            FacilitieDatacenterList = new List<FacilitieDatacenterListDto>();
            HardwareAssetList = new List<HardwareAsseDetailListDto>();
            VirtualHostList = new List<VirtualListDto>();
            VirtualMachineList = new List<VirtualListDto>();
            SytemApplicationList = new List<SytemApplicationDto>();

        }

        public int? TenantId { get; set; }
        public string FindingId { get; set; }
        public string FindingTitle { get; set; }
        public string FindingDetails { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? CategoryId { get; set; }
        public List<GetDynamicValueDto> CategoryList  { get; set; }
        public string CategoryOther { get; set; }
        public int? FindingStatusId { get; set; }
        public List<GetDynamicValueDto> FindingStatusList  { get; set; }
        public int? RankingId { get; set; }
        public List<GetDynamicValueDto> RankingList  { get; set; }
        public int? ClassificationId { get; set; }
        public List<GetDynamicValueDto> ClassificationList  { get; set; }
        public long? FindingManagerId { get; set; }
        public List<BusinessServiceOwner> FindingManagerList  { get; set; }
        public long? FindingCoordinatorId { get; set; }
        public List<BusinessServiceOwner> FindingCoordinatorList  { get; set; }
        public long? FindingOwnerId { get; set; }
        public List<BusinessServiceOwner> FindingOwnerList  { get; set; }
        public string Criteria { get; set; }
        public string Cause { get; set; }
        public string Condition { get; set; }
        public string Consequence { get; set; }
        public int? ActionId { get; set; }
        public List<GetDynamicValueDto> ActionLsit  { get; set; }
        public long? ReviewedId { get; set; }
        public List<BusinessServiceOwner> ReviewesList  { get; set; }
        public int? ResponseId { get; set; }
        public List<GetDynamicValueDto> Responses { get; set; }
        public int? PotentialCost { get; set; }
        public long? AssignedId { get; set; }
        public List<BusinessServiceOwner> AssignedList  { get; set; }

        public List<ProgramAuthoritativeDocumentsDto> AuthoritativeSourceList { get; set; }
        public List<AssetInformationListDto> AssetInformationList { get; set; }
        public List<BusinessUnitGaurdianDto> BusinessUnitList  { get; set; }
        public List<GetOrganizationDto> CompanyList { get; set; }
        public List<ControlDesignListDto> ControlDesignList  { get; set; }
        public List<ControlOperatingListDto> ControlOperatingList { get; set; }
        public List<FacilitieDatacenterListDto> FacilitieDatacenterList { get; set; }
        public List<HardwareAsseDetailListDto> HardwareAssetList  { get; set; }
        public List<VirtualListDto> VirtualHostList  { get; set; }
        public List<VirtualListDto> VirtualMachineList  { get; set; }         
        public List<SytemApplicationDto> SytemApplicationList { get; set; }
        public List<FindingIncidentListDto> FindingIncidentList { get; set; }
        public List<InternalControlListDto> InternalControlList { get; set; }
        public List<VendorListDto> VendorList { get; set; }
        public List<StrategicObjectivesDto> StrategicObjectiveList { get; set;}
        public List<RiskRegisterListDto> RiskRegisterList { get; set; }

        public List<FindingAssetInformationDto> SelectedFindingAssetInformations  { get; set; }
        public List<FindingAuthoratativeSourceDto> SelectedFindingAuthoratativeSources  { get; set; }
        public List<FindingBusinessUnitDto> SelectedFindingBusinessUnits  { get; set; }
        public List<FindingControlDesignDto> SelectedFindingControlDesigns  { get; set; }
        public List<FindingControlOperatingDto> SelectedFindingControlOperatings  { get; set; }
        public List<FindingFacilitieDatacenterDto> SelectedFindingFacilitieDatacenters  { get; set; }
        public List<FindingHardwareAssetDto> SelectedFindingHardwareAssets  { get; set; }
        public List<FindingIncidentDto> SelectedFindingIncidents  { get; set; }
        public List<FindingInternalControlDto> SelectedFindingInternalControls  { get; set; }
        public List<FindingOrganizationDto> SelectedFindingOrganizations  { get; set; }
        public List<FindingRiskRegisterDto> SelectedFindingRiskRegisters { get; set; }
        public List<FindingStrategicObjectiveDto> SelectedFindingStrategicObjectives { get; set; }
        public List<FindingSystemsApplicationDto> SelectedFindingSystemsApplications  { get; set; }
        public List<FindingVendorDto> SelectedFindingVendors  { get; set; }
        public List<FindingVirtualHostDto> SelectedFindingVirtualHosts  { get; set; }
        public List<FindingVirtualMachineDto> SelectedFindingVirtualMachines { get; set; }
       
      
    }

    public class FindingAssetInformationDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? AssetInformationId { get; set; }       
    }
    public class FindingAuthoratativeSourceDto 
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? AuthoratativeDocumentId { get; set; }
    }
    public class FindingBusinessUnitDto {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? BusinessUnitId { get; set; }
    }
    public class FindingControlDesignDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? ControlDesignsId { get; set; }
    }
    public class FindingControlOperatingDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? ControlOperatingTestId { get; set; }
    }
    public class FindingFacilitieDatacenterDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? FacilitieDatacenterId { get; set; }
    }
    public class FindingHardwareAssetDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? HardwareAssetId { get; set; }
    }
    public class FindingIncidentDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? IncidentId { get; set; }

    }
    public class FindingInternalControlDto 
    {        
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? InternalControlId { get; set; }
    }
    public class FindingOrganizationDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }

        public long? LockThreatOrganizationId { get; set; }
    }
    public class FindingRiskRegisterDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? RiskManagementId { get; set; }
    }
    public class FindingStrategicObjectiveDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? StrategicObjectiveId { get; set; }
    }
    public class FindingSystemsApplicationDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? SystemApplicationId { get; set; }
    }
    public class FindingVendorDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? VendorId { get; set; }
    }
    public class FindingVirtualHostDto
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? VirtualAssetId { get; set; }
    }
    public class FindingVirtualMachineDto 
    {
        public long Id { get; set; }
        public long? FindingId { get; set; }
        public long? VirtualAssetId { get; set; }
    }
    public class ControlDesignListDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
    }        
    public class ControlOperatingListDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        
    }
    public class FindingIncidentListDto
    {
        public long Id { get; set; }
        public string IncidentTitle { get; set; }
    }
    public class InternalControlListDto
    {
        public long Id { get; set; }

        public string ICTitle { get; set; }
    }
    public class VendorListDto
    {
        public long Id { get; set; }

        public string VendorName { get; set; }
    }  
    public class RiskRegisterListDto
    {
        public long Id { get; set; }
        public string RiskTitle { get; set; }
    }

    public class StrategicObjectivesDto
    {
        public long Id { get; set; }
        public string StrategicObjectiveTitle { get; set; }
    }
}
