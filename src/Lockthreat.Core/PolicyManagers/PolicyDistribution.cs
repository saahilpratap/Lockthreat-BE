using Abp.Domain.Entities.Auditing;
using Lockthreat.Policy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.PolicyManagers
{
  public class PolicyDistribution : FullAuditedEntity<long>
    {
        public long? PolicyManagerId { get; set; }
        public PolicyManager PolicyManager { get; set; }

        public PolicyDistributionMethod PolicyDistributionMethod { get; set; }
    }
}
