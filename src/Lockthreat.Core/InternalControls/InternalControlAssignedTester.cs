using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.InternalControls
{
  public  class InternalControlAssignedTester : FullAuditedEntity<long>
    {
        public long? InternalControlId { get; set; }

        public InternalControl InternalControl { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }

    }
}
