using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.AssetInformations
{
    [Table("AssetInformationBusinessServices")]
    public  class AssetInformationBusinessService : FullAuditedEntity<long>
    {
        public long? AssetInformationId { get; set; }
        public AssetInformation AssetInformation { get; set; }

        public long? BusinessServiceId { get; set; }
        public BusinessService BusinessService { get; set; }
    }
}
