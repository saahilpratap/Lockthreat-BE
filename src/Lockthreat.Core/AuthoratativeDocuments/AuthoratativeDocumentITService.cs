using Abp.Domain.Entities.Auditing;
using Lockthreat.ITServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.AuthoratativeDocuments 
{
  public  class AuthoratativeDocumentITService : FullAuditedEntity<long>
    {
        public long? AuthoratativeDocumentId  { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }

        public long? ITServiceId { get; set; }
        public ITService ITService { get; set; }

        
    }
}
