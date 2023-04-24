using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Audits 
{
    [Table("AuditBusinessServices")]
    public class AuditBusinessService : FullAuditedEntity<long>
    {
        public long? AuditId { get; set; }
        public Audit Audit { get; set; }

        public long? BusinessServiceId  { get; set; }
        public BusinessService BusinessService { get; set; }


    }
}
