using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.PolicyManagers
{
 public  class PolicyReviewer  : FullAuditedEntity<long>
    {
        public long? PolicyManagerId { get; set; }
        public PolicyManager PolicyManager { get; set; }

        public long? EmployeeId { get; set; }
        public Employee Employee  { get; set; }
    }
}
