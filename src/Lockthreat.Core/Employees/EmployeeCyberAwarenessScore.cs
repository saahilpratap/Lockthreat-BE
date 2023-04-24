using Abp.Domain.Entities.Auditing;
using Lockthreat.CyberAwarenessScores;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Employees 
{
 public   class EmployeeCyberAwarenessScore : FullAuditedEntity<long>
    {
        public long? EmployeeId  { get; set; }
        public Employee Employee { get; set; }

        public long? CyberAwarenessScoreId { get; set; }
        public CyberAwarenessScore CyberAwarenessScore { get; set; }

    }
}
