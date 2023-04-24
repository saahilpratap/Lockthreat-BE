using Abp.Domain.Entities.Auditing;
using Lockthreat.ReviewDatas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Employees 
{
 public   class EmployeeReviewData : FullAuditedEntity<long>
    {

        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public long? ReviewDataId  { get; set; }
        public ReviewData ReviewData { get; set; }

        
    }
}
