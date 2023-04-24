using Abp.Domain.Entities.Auditing;
using Lockthreat.Projects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.AddTasks
{
    [Table("TaskAssociatedProjects")]
    public class TaskAssociatedProject: FullAuditedEntity<long>
    {
        public long? AddTaskId { get; set; }
        public AddTask AddTask { get; set; }

        public long? ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
