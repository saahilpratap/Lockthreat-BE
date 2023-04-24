using Abp.Domain.Entities.Auditing;
using Lockthreat.Citations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ControlStandards
{
 public  class ControlStandardCitation  : FullAuditedEntity<long>
    {
        public long? ControlStandardId { get; set; }
        public ControlStandard ControlStandard { get; set; }

        public long? CitationId  { get; set; }
        public Citation Citation { get; set; }
       
    }
}
