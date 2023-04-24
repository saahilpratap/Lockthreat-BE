using Abp.Domain.Entities.Auditing;
using Lockthreat.CyberAwarenessScores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contacts
{
  public class ContactCyberAwarenessScore : FullAuditedEntity<long>
    {
        public long? ContactId  { get; set; }
        public Contact Contact { get; set; }

        public long? CyberAwarenessScoreId { get; set; }
        public CyberAwarenessScore CyberAwarenessScore { get; set; }

    }
}
