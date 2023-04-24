using Abp.Domain.Entities.Auditing;
using Lockthreat.Citations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.AuthoratativeDocuments 
{
 public   class AuthoratativeDocumentCitation : FullAuditedEntity<long>
    {
        public long? AuthoratativeDocumentId  { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }

        public long? CitationId  { get; set; }
        public Citation Citation { get; set; }
    }
}
