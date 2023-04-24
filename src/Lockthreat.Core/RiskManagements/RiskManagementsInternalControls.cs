using Abp.Domain.Entities.Auditing;
using Lockthreat.InternalControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.RiskManagements
{
  public class RiskManagementsInternalControls : FullAuditedEntity<long>
    {
        public long? RiskManagementId { get; set; }
        public RiskManagement RiskManagement { get; set; }

        public long? InternalControlId { get; set; }
        public InternalControl InternalControl { get; set; }

    }
}
