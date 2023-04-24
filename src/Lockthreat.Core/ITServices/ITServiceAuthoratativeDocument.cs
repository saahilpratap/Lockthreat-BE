using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocuments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.ITServices
{
    [Table("ITServiceAuthoratativeDocuments")]
    public   class ITServiceAuthoratativeDocument  : FullAuditedEntity<long>
    {
        public long? ITServiceId  { get; set; }
        public ITService ITService { get; set; }

        public long? AuthoratativeDocumentId  { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }

    }
}
