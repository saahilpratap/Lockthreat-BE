using Abp.Domain.Entities.Auditing;
using Lockthreat.StrategicObjectives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.RiskManagements
{
public  class RiskManagementStrategicObjectives : FullAuditedEntity<long> 
    {
        public long? RiskManagementId { get; set; }
        public RiskManagement RiskManagement { get; set; }

        public long? StrategicObjectiveId  { get; set; }
        public StrategicObjective StrategicObjective { get; set; }
        

    }
}
