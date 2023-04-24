using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.CyberAwarenessScores
{
   public class CyberAwarenessScoreBusinessUnit : FullAuditedEntity<long>
    {
        public long? CyberAwarenessScoreId { get; set; }
        public CyberAwarenessScore CyberAwarenessScore { get; set; }

        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }

    }
}
