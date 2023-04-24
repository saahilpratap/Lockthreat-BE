using Abp.Domain.Entities.Auditing;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.PolicyManagers
{
 public  class PolicyImpactedOranization  : FullAuditedEntity<long>
    {
        public long? PolicyManagerId  { get; set; }
        public PolicyManager PolicyManager { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }
    }
}
