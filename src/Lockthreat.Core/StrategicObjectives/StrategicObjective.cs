using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.StrategicObjectives
{
   public  class StrategicObjective : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string StrategicObjectiveId  { get; set; }
        public long? ExecutiveSponsorId  { get; set; }
        public Employee ExecutiveSponsor { get; set; }

        public string StrategicObjectiveTitle { get; set; }
        public string Description { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; }

        public int? TypeId  { get; set; }
        public DynamicParameterValue Type { get; set; }

        public string Goal { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }

    }
}
