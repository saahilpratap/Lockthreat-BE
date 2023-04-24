using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.SystemApplications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.FindingsInformation
{
 public   class FindingSystemsApplication : FullAuditedEntity<long>
    {

        public long? FindingId { get; set; }

        public Finding Finding { get; set; }
        public long? SystemApplicationId { get; set; }
        public SystemApplication SystemApplication { get; set; }
    }
}
