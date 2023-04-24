using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ControlProcedures
{
  public  class ControlProcedureBusinessProcess : FullAuditedEntity<long>
    {
        public long? ControlProcedureId  { get; set; }
        public ControlProcedure ControlProcedure { get; set; }

        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }

    }
}
