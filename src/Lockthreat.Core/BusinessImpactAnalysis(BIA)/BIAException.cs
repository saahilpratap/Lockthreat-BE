using Abp.Domain.Entities.Auditing;
using Lockthreat.Exceptions;
namespace Lockthreat.BusinessImpactAnalysis_BIA_
{
public    class BIAException : FullAuditedEntity<long>
    {
        public long? BusinessImpactAnalysisId { get; set; }
        public BusinessImpactAnalysis BusinessImpactAnalysis { get; set; }

        public long? ExceptionId  { get; set; }
        public Exception Exception  { get; set; }
    }
}
