using Abp.Domain.Entities.Auditing;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.ITServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.FacilitiesDatacenters
{
    [Table("FacilitieDatacenterITServices")]
    public   class FacilitieDatacenterITService : FullAuditedEntity<long>
    {
        public long? FacilitieDatacenterId  { get; set; }

        public FacilitieDatacenter FacilitieDatacenter { get; set; }

        public long? ITServiceId  { get; set; }
        public ITService ITService { get; set; }



    }
}
