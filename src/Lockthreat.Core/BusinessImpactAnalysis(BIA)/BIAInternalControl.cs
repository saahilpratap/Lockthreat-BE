using Abp.Domain.Entities.Auditing;
using Lockthreat.InternalControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessImpactAnalysis_BIA_
{
 public   class BIAInternalControl : FullAuditedEntity<long>
    {
        public long? BusinessImpactAnalysisId { get; set; }
        public BusinessImpactAnalysis BusinessImpactAnalysis { get; set; }

        public long? InternalControlId { get; set; }
        public InternalControl InternalControl { get; set; }

    }
}
