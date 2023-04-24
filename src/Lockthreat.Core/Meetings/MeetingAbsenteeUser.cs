using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Meetings 
{
 public  class MeetingAbsenteeUser : FullAuditedEntity<long>
    {
        public long? MeetingId  { get; set; }
        public Meeting Meeting  { get; set; }

        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
