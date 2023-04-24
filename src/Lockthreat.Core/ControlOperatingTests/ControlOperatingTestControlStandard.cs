using Abp.Domain.Entities.Auditing;
using Lockthreat.ControlStandards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ControlOperatingTests 
{
   public class ControlOperatingTestControlStandard : FullAuditedEntity<long>
    {
        public long? ControlOperatingTestId  { get; set; }
        public ControlOperatingTest ControlOperatingTest { get; set; }
        public long? ControlStandardId  { get; set; }
        public ControlStandard ControlStandard  { get; set; }

        
    }
}
