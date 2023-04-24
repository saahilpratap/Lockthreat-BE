using Abp.Domain.Entities.Auditing;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.FacilitiesDatacenters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Audits 
{
  public  class AuditFacilitieDatacenter  : FullAuditedEntity<long>
    {
        public long? AuditId { get; set; }
        public Audit Audit { get; set; }

        public long? FacilitieDatacenterId  { get; set; }

        public FacilitieDatacenter FacilitieDatacenter { get; set; }
    }
}
