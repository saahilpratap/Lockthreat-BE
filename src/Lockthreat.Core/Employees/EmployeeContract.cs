using Abp.Domain.Entities.Auditing;
using Lockthreat.Contracts;
using System;
using System.Collections.Generic;

using System.Text;

namespace Lockthreat.Employees 
{
  public  class EmployeeContract : FullAuditedEntity<long>
    {

        public long? ContractId { get; set; }

        public Contract Contract { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }

    }
}
