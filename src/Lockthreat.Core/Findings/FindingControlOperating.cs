using Abp.Domain.Entities.Auditing;
using Lockthreat.ControlOperatingTests;
using Lockthreat.Findings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Findings 
{
 public class FindingControlOperating : FullAuditedEntity<long>
    {
        public long? FindingId  { get; set; }
        public Finding Finding { get; set; }

        public long? ControlOperatingTestId { get; set; }
        public ControlOperatingTest ControlOperatingTest { get; set; }

    }
}
