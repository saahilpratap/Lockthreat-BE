using Abp.Domain.Entities.Auditing;
using Lockthreat.AssetInformations;
using Lockthreat.Findings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.FindingsInformation
{
    [Table("FindingAssetInformations")]
    public  class FindingAssetInformation : FullAuditedEntity<long>
    {
        public long? FindingId  { get; set; }

        public Finding Finding { get; set; }

        public long? AssetInformationId  { get; set; }
        public AssetInformation AssetInformation { get; set; }
       
    }
}
