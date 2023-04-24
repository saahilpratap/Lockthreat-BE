using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Audits
{
    [Table("AuditFindings")]
    public  class AuditFinding : FullAuditedEntity<long>
    {
        public long? AuditId { get; set; }
        public Audit Audit { get; set; }

        public long? FindingId { get; set; }

        public Finding Finding { get; set; }
    }
}
