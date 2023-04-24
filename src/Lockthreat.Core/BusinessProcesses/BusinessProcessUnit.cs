using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.BusinessProcesses
{
    [Table("BusinessProcessUnits")]
    public  class BusinessProcessUnit : FullAuditedEntity<long>
    {
        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }

        public long? BusinessUnitId  { get; set; }
        public BusinessUnit BusinessUnit  { get; set; }
    }
}
