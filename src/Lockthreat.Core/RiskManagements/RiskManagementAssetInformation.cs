using Abp.Domain.Entities.Auditing;
using Lockthreat.AssetInformations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.RiskManagements
{
  public  class RiskManagementAssetInformation : FullAuditedEntity<long>
    {
        public long? RiskManagementId { get; set; }
        public RiskManagement RiskManagement { get; set; }
        public long? AssetInformationId  { get; set; }
        public AssetInformation AssetInformation { get; set; } 
        
    }
}
