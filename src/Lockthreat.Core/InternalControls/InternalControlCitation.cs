using Abp.Domain.Entities.Auditing;
using Lockthreat.Citations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.InternalControls
{
 public   class InternalControlCitation: FullAuditedEntity<long>
    {
        public long? InternalControlId { get; set; }
        public InternalControl InternalControl { get; set; }

        public long? CitationId  { get; set; }
        public Citation Citation  { get; set; }


        
    }
}
