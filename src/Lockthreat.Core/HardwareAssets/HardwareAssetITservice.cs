using Abp.Domain.Entities.Auditing;
using Lockthreat.ITServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.HardwareAssets
{
    [Table("HardwareAssetITservices")]
    public class HardwareAssetITservice : FullAuditedEntity<long>
    {
        public long? HardwareAssetId { get; set; }
        public HardwareAsset HardwareAsset { get; set; }
        public long? ITServiceId { get; set; }
        public ITService ITService { get; set; }
    }
}
