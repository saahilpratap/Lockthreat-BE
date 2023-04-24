using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocuments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Projects 
{
    public class ProjectAuthoratativeDocument : FullAuditedEntity<long>
    {
        public long? ProjectId  { get; set; }
        public Project Project { get; set; }

        public long? AuthoratativeDocumentId { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }

    }
}
