using Abp.Domain.Entities.Auditing;
using Lockthreat.Exceptions;
namespace Lockthreat.RiskManagements
{
  public  class RiskManagementException  : FullAuditedEntity<long>
    {
        public long? RiskManagementId { get; set; }
        public RiskManagement RiskManagement { get; set; }

        public long? ExceptionId  { get; set; }
        public Exception Exception  { get; set; }
    }
}
