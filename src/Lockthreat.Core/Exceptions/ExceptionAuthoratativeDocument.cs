using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocuments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Exceptions 
{
  public  class ExceptionAuthoratativeDocument: FullAuditedEntity<long>
    {
        public long? AuthoratativeDocumentId { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }
        public long? ExceptionId  { get; set; }
        public Exception Exception { get; set; }
    }
}
