using Abp.Domain.Entities.Auditing;
using Lockthreat.Remediations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Exceptions
{ 
  public  class ExceptionRemediation : FullAuditedEntity<long>
    {
        public long? ExceptionId  { get; set; }
        public Exception Exception { get; set; }

        public long? RemediationId  { get; set; }
        public Remediation Remediation { get; set; }

    }
}
