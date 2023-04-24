using Abp.Domain.Entities.Auditing;
using Lockthreat.ITServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.VirtualAssets
{

    [Table("VirtualAssetITservices")]
    public  class VirtualAssetITservice : FullAuditedEntity<long>
    {
        public long? VirtualAssetId  { get; set; }
        public VirtualAsset VirtualAsset { get; set; }
        public long? ITServiceId { get; set; }
        public ITService ITService { get; set; }
    }
}
