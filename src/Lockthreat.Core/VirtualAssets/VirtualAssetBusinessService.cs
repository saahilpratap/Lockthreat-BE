using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.VirtualAssets
{

    [Table("VirtualAssetBusinessServices")]
    public  class VirtualAssetBusinessService : FullAuditedEntity<long>
    {
        public long? VirtualAssetId { get; set; }
        public VirtualAsset VirtualAsset { get; set; }
        public long? BusinessServiceId { get; set; }
        public BusinessService BusinessService { get; set; }
    }
}
