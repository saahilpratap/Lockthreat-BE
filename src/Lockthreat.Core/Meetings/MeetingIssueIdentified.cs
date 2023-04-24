using Abp.Domain.Entities.Auditing;
using Lockthreat.IssueManagements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Meetings 
{
 public  class MeetingIssueIdentified  : FullAuditedEntity<long>
    {
        
        public long? IssueManagementId  { get; set; }
        public IssueManagement IssueManagement { get; set; }
        public long? MeetingId  { get; set; }
        public Meeting Meeting  { get; set; }
    }
}
