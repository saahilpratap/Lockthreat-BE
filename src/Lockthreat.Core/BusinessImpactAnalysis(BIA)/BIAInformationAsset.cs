using Abp.Domain.Entities.Auditing;
using Lockthreat.AssetInformations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessImpactAnalysis_BIA_
{
 public   class BIAInformationAsset : FullAuditedEntity<long>
    {
        public long? BusinessImpactAnalysisId { get; set; }
        public BusinessImpactAnalysis BusinessImpactAnalysis { get; set; }

        public long? AssetInformationId  { get; set; }
        public AssetInformation AssetInformation { get; set; }
        
    }
}
