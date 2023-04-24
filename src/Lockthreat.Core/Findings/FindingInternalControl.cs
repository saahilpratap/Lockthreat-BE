using Abp.Domain.Entities.Auditing;
using Lockthreat.InternalControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Findings 
{
   public class FindingInternalControl : FullAuditedEntity<long>
    {
        public long? InternalControlId { get; set; }
        public InternalControl InternalControl { get; set; }

        public long? FindingId  { get; set; }
        public Finding Finding { get; set; }
    }
}
