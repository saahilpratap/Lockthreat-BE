using Abp.Domain.Entities.Auditing;
using Lockthreat.RiskManagements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.InternalControls
{
 public  class InternalControlRiskManagementTitle : FullAuditedEntity<long>
    {
        public long? RiskManagementId { get; set; }
        public RiskManagement RiskManagement { get; set; }

        public long? InternalControlId { get; set; }
        public InternalControl InternalControl { get; set; }
    }
}
