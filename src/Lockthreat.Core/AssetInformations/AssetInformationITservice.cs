using Abp.Domain.Entities.Auditing;
using Lockthreat.ITServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.AssetInformations
{
    [Table("AssetInformationITservices")]
    public  class AssetInformationITservice : FullAuditedEntity<long>
    {
        public long? AssetInformationId  { get; set; }
        public AssetInformation AssetInformation { get; set; }
        public long? ITServiceId { get; set; }
        public ITService ITService { get; set; }
      
    }
}
