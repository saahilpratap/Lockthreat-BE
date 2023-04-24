using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.SystemApplications
{
    [Table("SysteamApplicationBusinessProcess")]
    public  class SysteamApplicationBusinessProcess : FullAuditedEntity<long>
    {
        public long? SystemApplicationId { get; set; }
        public SystemApplication SystemApplication { get; set; }
        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }
    }
}
