using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Audits 
{
    [Table("AuditWorkpapers")]
    public  class AuditWorkpaper : FullAuditedEntity<long>
    {
        public string WorkpaperId { get; set; }

        public string Description { get; set; }

        [Required]
        public string WorkpaperTitle { get; set; }

        public DateTime? PreparedOn { get; set; }

        public int? AuditId  { get; set; }
        public Audit Audit  { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }

        public int? TypeId  { get; set; }
        public DynamicParameterValue Type { get; set; }

       public string Signature { get; set; }

        public string Notes { get; set; }

        public string WorkpaperAttachment { get; set; }

        public string WorkpaperLink { get; set; }


    }
}
