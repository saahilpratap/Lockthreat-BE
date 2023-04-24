using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.BusinessProcesses
{
    [Table("BusinessProcessServices")]
    public  class BusinessProcessService : FullAuditedEntity<long>
    {
        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }
        public long? BusinessServiceId  { get; set; }
        public BusinessService BusinessService { get; set; }
    }
}
