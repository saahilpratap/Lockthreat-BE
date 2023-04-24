using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.AddTasks
{

    [Table("TaskRelatedMembers")]
    public class TaskRelatedMember : FullAuditedEntity<long>
    {
        public long? AddTaskId { get; set; }
        public AddTask AddTask { get; set; }

        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
