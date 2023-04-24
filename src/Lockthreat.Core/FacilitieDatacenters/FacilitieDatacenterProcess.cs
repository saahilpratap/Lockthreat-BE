using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.FacilitieDatacenters 
{
    [Table("FacilitieDatacenterBusinessProcess")]
    public  class FacilitieDatacenterProcess : FullAuditedEntity<long>
    {

        public long? FacilitieDatacenterId  { get; set; }

        public FacilitieDatacenter FacilitieDatacenter { get; set; }

        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }

        
    }
}
