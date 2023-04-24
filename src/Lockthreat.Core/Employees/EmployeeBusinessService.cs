using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Employees 
{
    [Table("EmployeeBusinessServices")]
    public   class EmployeeBusinessService : FullAuditedEntity<long>
    {
        public long? BusinessServiceId  { get; set; }
        public BusinessService BusinessService { get; set; }

        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }


    }
}
