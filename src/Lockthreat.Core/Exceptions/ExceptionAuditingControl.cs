using Abp.Domain.Entities.Auditing;
using Lockthreat.Citations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Exceptions
{ 
  public  class ExceptionAuditingControl  : FullAuditedEntity<long>
    {
        public long? ExceptionId  { get; set; }
        public Exception Exception { get; set; }

        public long? CitationId  { get; set; }
        public Citation Citation { get; set; }

    }
}
