using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessEntities;
using Lockthreat.Employees;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.FacilitiesDatacenters;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.HardwareAssets
{
    [Table("HardwareAssets")]
    public  class HardwareAsset : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string AssetId { get; set; }

        public string HardwareAssetName { get; set; }

        public string Description { get; set; }

        public string AssetHardwareId { get; set; }

        public long? LocationsId { get; set; }

        public FacilitieDatacenter Locations { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }

        public long? BusinessUnitOwnerId { get; set; }
        public BusinessUnit BusinessUnitOwner { get; set; }

        public long? BusinessUnitGaurdianId { get; set; }
        public BusinessUnit BusinessUnitGaurdian { get; set; }

        public int? ConfidentialityId { get; set; }
        public DynamicParameterValue Confidentiality  { get; set; }

        public int? AvailibilityId { get; set; }
        public DynamicParameterValue Availibility  { get; set; }

        public int? OthersId { get; set; }
        public DynamicParameterValue Others  { get; set; }

        public int? IntegrityId { get; set; }
        public DynamicParameterValue Integrity  { get; set; }

        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public ICollection<HardwareAssetITservice> SelectedHardwareAssetITServices  { get; set; }
        public ICollection<HardwareAssetBusinessprocess> SelectedHardwareAssetBusinessProcess{ get; set; }
        public ICollection<HardwareAssetBusinessService> SelectedHardwareAssetBusinessServices { get; set; }


    }
}
