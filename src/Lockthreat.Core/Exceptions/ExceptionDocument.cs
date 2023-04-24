using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Exceptions 
{
 public class ExceptionDocument  : FullAuditedEntity<long>
    {
        public long? ExceptionId  { get; set; }
        public Exception Exception { get; set; }

        public string Document  { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

    }
}
