using Abp.Domain.Entities.Auditing;
using Lockthreat.ControlStandards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Citations 
{
 public  class CitationControlStandard : FullAuditedEntity<long>
    {
        public long? CitationId { get; set; }
        public Citation Citation { get; set; }
        
        public long? ControlStandardId { get; set; }
        public ControlStandard ControlStandard { get; set; }
    }
}
