using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Employees 
{
    [Table("EmployeeAttachments")]
    public class EmployeeAttachment : FullAuditedEntity<long>
    {
        public long? EmployeeId {get;set;}
        public Employee Employee { get; set; }

        public string Document { get; set; }
    }
}
