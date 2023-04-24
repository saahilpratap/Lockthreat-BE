using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.RiskManagements
{
 public  class RiskAttachments: FullAuditedEntity<long>
    {
        public long? RiskManagementId  { get; set; }
        public RiskManagement RiskManagement { get; set; }

        public string AttachmentTitle { get; set; }
        public string Document { get; set; }

        public long? OwnerId  { get; set; }
        public Employee Owner  { get; set; }

    }
}
