using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.StrategicObjectives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.FindingsInformation
{
  public  class FindingStrategicObjective : FullAuditedEntity<long>
    {
        public long? FindingId  { get; set; }
        public Finding Finding { get; set; }

        public long? StrategicObjectiveId { get; set; }
        public StrategicObjective StrategicObjective { get; set; }

    }
}
