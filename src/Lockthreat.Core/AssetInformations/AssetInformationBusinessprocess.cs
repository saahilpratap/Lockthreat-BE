using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.AssetInformations
{
    [Table("AssetInformationBusinessprocess")]

    public class AssetInformationBusinessprocess : FullAuditedEntity<long>
    {
        public long? AssetInformationId { get; set; }
        public AssetInformation AssetInformation { get; set; }

        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }
    }
}
