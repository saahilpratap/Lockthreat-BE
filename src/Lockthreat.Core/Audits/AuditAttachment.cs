using Abp.Domain.Entities.Auditing;
using Lockthreat.Audits;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Audits 
{
    [Table("AuditAttachments")]
    public  class AuditAttachment : FullAuditedEntity<long>
    {
        public long? AuditId  { get; set; }
        public Audit Audit  { get; set; }
        
        public string Documents { get; set; }
    }
}
