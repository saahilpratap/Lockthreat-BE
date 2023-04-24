using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.VirtualAssets
{
    [Table("VirtualAssetBusinessprocess")]
    public class VirtualAssetBusinessprocess : FullAuditedEntity<long>
    {
        public long? VirtualAssetId { get; set; }
        public VirtualAsset VirtualAsset { get; set; }
        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }
    }
}
