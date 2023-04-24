using Abp.Domain.Entities.Auditing;
using Lockthreat.StrategicObjectives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessImpactAnalysis_BIA_
{
  public  class BIAStrategicObjective : FullAuditedEntity<long>
    {
        public long? BusinessImpactAnalysisId { get; set; }
        public BusinessImpactAnalysis BusinessImpactAnalysis { get; set; }

        public long? StrategicObjectiveId  { get; set; }
        public StrategicObjective StrategicObjective { get; set; }
        
    }
}
