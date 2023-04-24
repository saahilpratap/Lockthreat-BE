using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocuments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.CyberAwarenessScores
{
 public  class CyberAwarenessScoreAuthoratativeDocument : FullAuditedEntity<long>
    {
        public long? CyberAwarenessScoreId { get; set; }
        public CyberAwarenessScore CyberAwarenessScore { get; set; }

        public long? AuthoratativeDocumentId { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }
    }
}
