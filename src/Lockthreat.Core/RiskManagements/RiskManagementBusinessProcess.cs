using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.RiskManagements
{
 public   class RiskManagementBusinessProcess : FullAuditedEntity<long>
    {
        public long? RiskManagementId { get; set; }
        public RiskManagement RiskManagement { get; set; }

        public long? BusinessProcessId  { get; set; }
        public BusinessProcess BusinessProcess  { get; set; }
        
    }
}
