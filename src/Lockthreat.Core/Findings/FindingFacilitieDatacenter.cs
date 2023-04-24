using Abp.Domain.Entities.Auditing;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.FacilitiesDatacenters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Findings 
{
  public  class FindingFacilitieDatacenter : FullAuditedEntity<long>
    {
        public long? FindingId  { get; set; }
        public Finding Finding { get; set; }

        public long? FacilitieDatacenterId  { get; set; }
        public FacilitieDatacenter FacilitieDatacenter { get; set; }

    }
}
