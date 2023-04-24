using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ControlOperatingTests 
{
  public  class ControlTestBusinessProcess : FullAuditedEntity<long>
    {
        public long? ControlOperatingTestId { get; set; }
        public ControlOperatingTest ControlOperatingTest { get; set; }

        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }
    }
}
