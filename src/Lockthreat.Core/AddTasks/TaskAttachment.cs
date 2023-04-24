using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.AddTasks
{
    [Table("TaskAttachments")]
    public class TaskAttachment  : FullAuditedEntity<long>
    {
        public long? AddTaskId  { get; set; }
        public AddTask AddTask  { get; set; }

        public string Document { get; set; }
    }
}
