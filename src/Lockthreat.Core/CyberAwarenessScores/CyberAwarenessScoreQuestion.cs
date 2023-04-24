using Abp.Domain.Entities.Auditing;
using Lockthreat.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.CyberAwarenessScores
{
 public   class CyberAwarenessScoreQuestion  : FullAuditedEntity<long>
    {
        public long? CyberAwarenessScoreId { get; set; }
        public CyberAwarenessScore CyberAwarenessScore { get; set; }

        public long? QuestionId  { get; set; }
        public Question Question  { get; set; }
    }
}
