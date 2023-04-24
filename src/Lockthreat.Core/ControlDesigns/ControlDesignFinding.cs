using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.FindingsInformation;
using Lockthreat.InternalControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ControlDesigns
{
   public class ControlDesignFinding  : FullAuditedEntity<long>
    {
        public long? ControlDesignId  { get; set; }
        public ControlDesign ControlDesign { get; set; }

        public long? FindingId  { get; set; }
        public Finding Finding  { get; set; }

    }
}
