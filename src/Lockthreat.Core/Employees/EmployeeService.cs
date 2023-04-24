using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Employees 
{
  public  class EmployeeService  : FullAuditedEntity<long>
    {
        public long? BusinessServiceId  { get; set; }
        public BusinessService BusinessService { get; set; }

        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
