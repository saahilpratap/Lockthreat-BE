using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.KeyRiskIndicators
{
  public  class KeyRiskIndicator : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string KeyRiskIndicatorsId { get; set; }

        public int? StatusId { get; set; }
        public DynamicParameterValue Status  { get; set; }
        [Required]
        public string KeyRiskIndicatorTitle { get; set;}

        public string Description { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }
        public ICollection<KeyRiskIndicatorBusinessUnit> SelectdBusinessUnits  { get; set; }
    }
}
