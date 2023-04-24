using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Audits;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Audits 
{
    [Table("AuditWorkpaperEvidences")]
    public class AuditWorkpaperEvidence  : FullAuditedEntity<long>
    {
       
        public int? DocumentSourceId { get; set; }
        public DynamicParameterValue DocumentSource  { get; set; }
        public string Attachment { get; set; }

        public string DocumentLink { get; set; }

        public string Comment  { get; set; }
        public long? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public long? AuditId { get; set; }
        public Audit Audit { get; set; }

    }
}
