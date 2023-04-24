using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.FindingsInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.AuthoratativeDocuments 
{
   public class AuthoratativeDocumentFinding : FullAuditedEntity<long>
    {

        public long? AuthoratativeDocumentId { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }

        public long? FindingId  { get; set; }
        public Finding Finding  { get; set; }
        
    }
}
