using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.KeyRiskIndicator.Dto
{
  public  class KeyRiskIndicatorDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string KeyRiskIndicatorsId { get; set; }
        public int? StatusId { get; set; }     
        public List<GetDynamicValueDto> Statuses { get; set; }
        public string KeyRiskIndicatorTitle { get; set; }
        public string Description { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; }
        public List<long> RemoveBusinessUnit { get; set; }
        public List<BusinessUnitPrimaryDto> BusinessUnits { get; set; }
        public List<BusinessUnitKeyRiskDto> SelectdBusinessUnits { get; set; }
    }
}
