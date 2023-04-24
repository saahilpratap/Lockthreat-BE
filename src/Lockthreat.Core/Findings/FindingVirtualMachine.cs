using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.VirtualAssets;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Findings 
{
  public  class FindingVirtualMachine  : FullAuditedEntity<long>
    {
        public long? FindingId  { get; set; }
        public Finding Finding { get; set; }
        public long? VirtualAssetId  { get; set; }
        public VirtualAsset VirtualAsset { get; set; }


    }
}
