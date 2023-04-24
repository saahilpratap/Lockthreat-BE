using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocuments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.PolicyManagers
{
  public  class PolicyAuthoratativeDocument  : FullAuditedEntity<long>
    {

        public long? PolicyManagerId { get; set; }
        public PolicyManager PolicyManager { get; set; }

        public long? AuthoratativeDocumentsId { get; set; }
        public AuthoratativeDocument  AuthoratativeDocuments { get; set; }

    }
}
