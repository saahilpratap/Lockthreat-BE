using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.FindingsInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessImpactAnalysis_BIA_
{
 public   class BIAFinding : FullAuditedEntity<long>
    {
        public long? BusinessImpactAnalysisId { get; set; }
        public BusinessImpactAnalysis BusinessImpactAnalysis { get; set; }

        public long? FindingId  { get; set; }
        public Finding Finding  { get; set; }

    }
}
