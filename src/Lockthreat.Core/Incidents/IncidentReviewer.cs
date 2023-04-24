using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Incidents
{

    [Table("IncidentReviewers")]
    public   class IncidentReviewer  : FullAuditedEntity<long>
    {
        public long? IncidentId { get; set; }
        public Incident Incident { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }

    }
}
