using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.CyberAwarenessScores
{
 public   class CyberAwarenessScoreEmployee  : FullAuditedEntity<long>
    {
        public long? CyberAwarenessScoreId  { get; set; }
        public CyberAwarenessScore CyberAwarenessScore { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }


    }
}
