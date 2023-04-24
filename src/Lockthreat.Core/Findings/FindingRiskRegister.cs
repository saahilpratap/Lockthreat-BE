using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.RiskManagements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.FindingsInformation
{
 public class FindingRiskRegister : FullAuditedEntity<long>
    {
        public long? FindingId  { get; set; }
        public Finding Finding { get; set; }
        public long? RiskManagementId { get; set; }
        public RiskManagement RiskManagement { get; set; }
    }
}
