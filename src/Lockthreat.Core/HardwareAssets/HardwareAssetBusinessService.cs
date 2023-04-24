using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.HardwareAssets
{

    [Table("HardwareAssetBusinessServices")]
    public  class HardwareAssetBusinessService : FullAuditedEntity<long>
    {
        public long? HardwareAssetId { get; set; }
        public HardwareAsset HardwareAsset { get; set; }
        public long? BusinessServiceId { get; set; }
        public BusinessService BusinessService { get; set; }
    }
}
