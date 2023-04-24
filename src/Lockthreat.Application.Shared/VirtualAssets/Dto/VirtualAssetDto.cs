using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.VirtualAssets.Dto
{
 public  class VirtualAssetDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string VirtualAssetId { get; set; }   
        public string VirtualAssetName { get; set; }
        public string VirtualAssetUniqueIdentity { get; set; }
        public bool VirtualMachine { get; set; }
        public string Description { get; set; }
        public long? ParentVirtualHostId { get; set; }
        public List<ParentVirtualHostListDto> ParentVirtualHostList  { get; set; }
        public long? HostedServerNameId { get; set; }
        public List<HardwareAsseDetailListDto> HardwareAssetList  { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; }
        public long? BusinessUnitId { get; set; }
        public List<BusinessUnitPrimaryDto> BusinessUnitOwners { get; set; }
        public long? BusinessUnitGaurdianId { get; set; }
        public List<BusinessUnitGaurdianDto> BusinessUnitGaurdians { get; set; }
        public long? BusinessOwnerId  { get; set; }
        public List<BusinessServiceOwner> EmployeesList { get; set; }
        public List<ITserviceListDto> ITserviceLists { get; set; }
        public List<BusinessServiceSDto> BusinessServices { get; set; }
        public List<BusinessProcessDetailDto> BusinessProcess { get; set; }

        public int? ConfidentialityId { get; set; }
        public List<GetDynamicValueDto> Confidentialitys { get; set; }
        public int? AvailibilityId { get; set; }
        public List<GetDynamicValueDto> Availibilitys { get; set; }
        public int? IntegrityId { get; set; }
        public List<GetDynamicValueDto> Integritys { get; set; }
        public int? OthersId { get; set; }
        public List<GetDynamicValueDto> Otheres { get; set; }

        public List<VirtualAssetITserviceDto> SelectedVirtualAssetITservices { get; set; }
        public List<VirtualAssetBusinessprocessDto> SelectedVirtualAssetBusinessprocess { get; set; }
        public List<VirtualAssetBusinessServiceDto> SelectedVirtualAssetBusinessServices { get; set; }
        public List<long> RemovedVirtualAssetITservice  { get; set; }
        public List<long> RemovedVirtualAssetBusinessprocess { get; set; }
        public List<long> RemovedVirtualAssetBusinessServices { get; set; }

    }

    public class  VirtualAssetITserviceDto
    {
        public long Id { get; set; }
        public long? VirtualAssetId  { get; set; }
        public long? ITServiceId { get; set; }
    }
    public class VirtualAssetBusinessprocessDto
    {
        public long Id { get; set; }
        public long? VirtualAssetId  { get; set; }
        public long? BusinessProcessId { get; set; }
    }
    public class VirtualAssetBusinessServiceDto
    {
        public long Id { get; set; }
        public long? VirtualAssetId  { get; set; }
        public long? BusinessServiceId { get; set; }
    }
    public class HardwareAsseDetailListDto
    {
        public long Id { get; set; }
        public string HardwareAssetName { get; set; }
    }

    public class VirtualListDto
    {
        public long Id { get; set; }
        public string VirtualAssetName { get; set; }

    }

    public class ParentVirtualHostListDto
    {
        public long Id { get; set; }
        public long? HostedServerNameId { get; set; }
        public string VirtualAssetName { get; set; }
    }
}
