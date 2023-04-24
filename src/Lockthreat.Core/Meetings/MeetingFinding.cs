using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Meetings 
{
 public  class MeetingFinding : FullAuditedEntity<long>
    {
        public long? FindingId { get; set; }
        public Finding Finding { get; set; }
        public long? MeetingId  { get; set; }
        public Meeting Meeting  { get; set; }
    }
}
