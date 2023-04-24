using Abp.Domain.Entities.Auditing;
using Lockthreat.RiskManagements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Exceptions
{
 public  class ExceptionRiskManagement : FullAuditedEntity<long>
    {
        public long? ExceptionId { get; set; }
        public Exception Exception { get; set; }

        public long? RiskManagementId  { get; set; }
        public RiskManagement RiskManagement { get; set; }
    }
}
