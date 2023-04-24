using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Audits 
{
    [Table("AuditBusinessProcess")]
    public  class AuditBusinessProcess : FullAuditedEntity<long>
    {
        public long? AuditId { get; set; }
        public Audit Audit { get; set; }
        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }
    }
}
