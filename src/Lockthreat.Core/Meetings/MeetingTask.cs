using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.AddTasks;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Meetings 
{
 public class MeetingTask:FullAuditedEntity<long>
    {
        public long? AddTaskId { get; set; }
        public AddTask AddTask { get; set; }
        public long? MeetingId  { get; set; }
        public Meeting Meeting  { get; set; }
    }
}
