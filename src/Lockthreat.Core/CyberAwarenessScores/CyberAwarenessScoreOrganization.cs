using Abp.Domain.Entities.Auditing;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.CyberAwarenessScores
{
 public  class CyberAwarenessScoreOrganization : FullAuditedEntity<long>
    {
        public long? CyberAwarenessScoreId { get; set; }
        public CyberAwarenessScore CyberAwarenessScore { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }

    }
}
