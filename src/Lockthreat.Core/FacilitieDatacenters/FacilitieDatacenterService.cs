using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.FacilitieDatacenters 
{
    [Table("FacilitieDatacenterBusinessServices")]
    public  class FacilitieDatacenterService : FullAuditedEntity<long>
    {
        public long? BusinessServiceId  { get; set; }
        public BusinessService BusinessService { get; set; }

        public long? FacilitieDatacenterId { get; set; }
        public FacilitieDatacenter FacilitieDatacenter { get; set; }

    }
}
