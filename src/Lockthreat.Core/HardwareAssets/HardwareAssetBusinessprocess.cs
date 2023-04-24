using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.HardwareAssets
{
    [Table("HardwareAssetBusinessProcess")]
    public  class HardwareAssetBusinessprocess : FullAuditedEntity<long>
    {
        public long? HardwareAssetId  { get; set; }
        public HardwareAsset HardwareAsset { get; set; }
        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }
    }
}
