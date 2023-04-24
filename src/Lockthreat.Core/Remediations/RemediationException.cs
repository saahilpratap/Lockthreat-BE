using Abp.Domain.Entities.Auditing;
using Lockthreat.Exceptions;


namespace Lockthreat.Remediations 
{
  public  class RemediationException  : FullAuditedEntity<long>
    {
        public long? RemediationId  { get; set; }
        public Remediation Remediation { get; set; }

        public long? ExceptionId  { get; set; }
        public Exception Exception { get; set; }

    }
}
