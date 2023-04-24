using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Audits 
{
    [Table("AuditWorkpaperReviewers")]
    public   class AuditWorkpaperReviewer : FullAuditedEntity<long>
    {
        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }

        public long? AuditWorkpaperId  { get; set; }
        public AuditWorkpaper AuditWorkpaper { get; set; }


    }
}
