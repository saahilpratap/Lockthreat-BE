using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contracts
{
 public  class ContractEmployee : FullAuditedEntity<long>
    {
        public long? ContractId  { get; set; }

        public Contract Contract  { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }
        


    }
}
