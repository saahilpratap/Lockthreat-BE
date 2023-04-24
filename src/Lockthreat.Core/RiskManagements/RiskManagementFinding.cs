using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.FindingsInformation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.RiskManagements
{
  public class RiskManagementFinding : FullAuditedEntity<long>
    {
        public long? RiskManagementId { get; set; }
        public RiskManagement RiskManagement { get; set; }
        public long? FindingId  { get; set; }
        public Finding Finding  { get; set; }
    }
}
