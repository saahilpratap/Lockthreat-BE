using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocuments;
using Lockthreat.Findings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.FindingsInformation
{
    [Table("FindingAuthoratativeSources")]
    public class FindingAuthoratativeSource : FullAuditedEntity<long>
    {
        public long? FindingId  { get; set; }

        public Finding Finding { get; set; }

        public long? AuthoratativeDocumentId  { get; set; }
        public AuthoratativeDocument AuthoratativeDocument  { get; set; }

    }
}
