using Abp.Domain.Entities.Auditing;
using Lockthreat.ControlStandards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ControlProcedures
{
  public  class ControlProcedureControlStandard : FullAuditedEntity<long>
    {
        public long? ControlProcedureId  { get; set; }
        public ControlProcedure ControlProcedure { get; set; }

        public long? ControlStandardId  { get; set; }
        public ControlStandard ControlStandard { get; set; }

        
    }
}
