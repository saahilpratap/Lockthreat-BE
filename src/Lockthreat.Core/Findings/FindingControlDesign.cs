using Abp.Domain.Entities.Auditing;
using Lockthreat.ControlDesigns;
using Lockthreat.Findings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.FindingsInformation
{
  public  class FindingControlDesign : FullAuditedEntity<long>
    {
        public long? FindingId  { get; set; }
        public Finding Finding { get; set; }

        public long? ControlDesignsId { get; set; }
        public ControlDesign ControlDesigns { get; set; }


    }
}
