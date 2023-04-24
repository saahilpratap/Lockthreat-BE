using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Exceptions 
{
   public class ExceptionBusinessUnit : FullAuditedEntity<long>
    {
        public long? ExceptionId  { get; set; }
        public Exception Exception  { get; set; }

        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
    }
}
