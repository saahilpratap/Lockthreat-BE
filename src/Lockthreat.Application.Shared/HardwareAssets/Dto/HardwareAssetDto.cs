using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.HardwareAssets.Dto
{
  public  class HardwareAssetDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string AssetId { get; set; }
        public string HardwareAssetName { get; set; }
        public string Description { get; set; }
        public string AssetHardwareId { get; set; }
        public long? LocationsId { get; set; }
        public List<FacilitieDatacenterListDto> LocationLists  { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public long? BusinessUnitOwnerId { get; set; }
        public List<BusinessUnitPrimaryDto> BusinessUnitOwners { get; set; }
        public long? BusinessUnitGaurdianId { get; set; }
        public List<BusinessUnitGaurdianDto> BusinessUnitGaurdians { get; set; }
        public long? EmployeeId { get; set; }
        public List<BusinessServiceOwner> EmployeesList { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; }
        public int? ConfidentialityId { get; set; }
        public List<GetDynamicValueDto> Confidentialitys { get; set; }
        public int? AvailibilityId { get; set; }
        public List<GetDynamicValueDto> Availibilitys { get; set; }
        public int? OthersId { get; set; }
        public List<GetDynamicValueDto> Otheres { get; set; }
        public int? IntegrityId { get; set; }
        public List<GetDynamicValueDto> Integritys { get; set; }
        public List<ITserviceListDto> ITserviceLists { get; set; }
        public List<BusinessServiceSDto> BusinessServices { get; set; }
        public List<BusinessProcessDetailDto> BusinessProcess { get; set; }
        public List<HardwareAssetITserviceDto> SelectedHardwareAssetITservices   { get; set; }
        public List<HardwareAssetBusinessprocessDto> SelectedHardwareAssetBusinessprocess  { get; set; }
        public List<HardwareAssetBusinessServiceDto> SelectedHardwareAssetBusinessServices  { get; set; }
        public List<long> RemovedHardwareAssetITservice  { get; set; }
        public List<long> RemovedHardwareAssetBusinessprocess { get; set; }
        public List<long> RemovedHardwareAssetBusinessService  { get; set; }
    }

    public class HardwareAssetITserviceDto
    {
        public long Id { get; set; }
        public long? HardwareAssetId { get; set; }
        public long? ITServiceId { get; set; }
    }

    public class HardwareAssetBusinessprocessDto 
    {
        public long Id { get; set; }
        public long? HardwareAssetId { get; set; }
        public long? BusinessProcessId { get; set; }
    }

    public class HardwareAssetBusinessServiceDto 
    {
        public long Id { get; set; }
        public long? HardwareAssetId { get; set; }
        public long? BusinessServiceId { get; set; }
    }

    public class FacilitieDatacenterListDto
    {
        public long Id { get; set; }
        public string FacilityName { get; set; }       
    }

}
