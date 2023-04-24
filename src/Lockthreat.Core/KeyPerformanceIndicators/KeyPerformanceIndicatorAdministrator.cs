using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.KeyPerformanceIndicators
{
 public   class KeyPerformanceIndicatorAdministrator : FullAuditedEntity<long>
    {
        public long? KeyPerformanceIndicatorId  { get; set; }
        public KeyPerformanceIndicator KeyPerformanceIndicator { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }
    }
}
