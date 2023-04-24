using Abp.Domain.Entities.Auditing;
using Lockthreat.RiskManagements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Remediations 
{
  public  class RemediationRiskManagement : FullAuditedEntity<long>
    {
        public long? RemediationId  { get; set; }
        public Remediation Remediation  { get; set; }

        public long? RiskManagementId { get; set; }
        public RiskManagement RiskManagement { get; set; }

    }
}
