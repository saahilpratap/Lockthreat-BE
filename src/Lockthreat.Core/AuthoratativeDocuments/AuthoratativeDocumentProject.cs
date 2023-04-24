using Abp.Domain.Entities.Auditing;
using Lockthreat.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.AuthoratativeDocuments 
{
 public   class AuthoratativeDocumentProject : FullAuditedEntity<long>
    {
        public long? AuthoratativeDocumentId  { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }

        public long? ProjectId  { get; set; }
        public Project Project { get; set; }

        
    }
}
