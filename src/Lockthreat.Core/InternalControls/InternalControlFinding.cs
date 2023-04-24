using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.InternalControls
{
    [Table("InternalControlFindings")]
    public  class InternalControlFinding : FullAuditedEntity<long>
    {
        public long? InternalControlId { get; set; }
        public InternalControl InternalControl { get; set; }

        public long? FindingId  { get; set; }
        public Finding Finding { get; set; }
    }
}
