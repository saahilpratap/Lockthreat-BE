using Abp.Domain.Entities.Auditing;
using Lockthreat.SystemApplications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Audits
{
    [Table("AuditSystemApplications")]
    public  class AuditSystemApplication : FullAuditedEntity<long>
    {
        public long? AuditId { get; set; }
        public Audit Audit { get; set; }
        public long? SystemApplicationId  { get; set; }
        public SystemApplication SystemApplication { get; set; }
        
    }
}
