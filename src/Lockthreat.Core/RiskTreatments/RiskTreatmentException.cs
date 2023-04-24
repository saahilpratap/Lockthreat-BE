using Abp.Domain.Entities.Auditing;
using Lockthreat.Exceptions;
namespace Lockthreat.RiskTreatments 
{
  public  class RiskTreatmentException : FullAuditedEntity<long>
    {
        public long? RiskTreatmentId  { get; set; }
        public RiskTreatment RiskTreatment { get; set; }

        public long? ExceptionId  { get; set; }
        public Exception  Exception { get; set; }
    }
}
