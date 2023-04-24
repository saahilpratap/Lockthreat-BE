using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessImpactAnalysis_BIA_
{
public  class BIABusinessProcess : FullAuditedEntity<long>
    {
        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }

        public long? BusinessImpactAnalysisId  { get; set; }
        public BusinessImpactAnalysis BusinessImpactAnalysis { get; set; }



        
    }
}
