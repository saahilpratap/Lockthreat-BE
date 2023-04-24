using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ControlOperatingTests 
{
  public  class ControlOperatingTestFinding : FullAuditedEntity<long>
    {
        public long? ControlOperatingTestId { get; set; }
        public ControlOperatingTest ControlOperatingTest { get; set; }

        public long? FindingId  { get; set; }
        public Finding Finding  { get; set; }


    }
}
