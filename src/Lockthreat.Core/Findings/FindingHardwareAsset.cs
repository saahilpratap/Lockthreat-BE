using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.HardwareAssets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Findings 
{
  public  class FindingHardwareAsset: FullAuditedEntity<long>
    {
        public long? FindingId  { get; set; }
        public Finding Finding { get; set; }
        public long? HardwareAssetId  { get; set; }
        public HardwareAsset HardwareAsset { get; set; }        
    }
}
