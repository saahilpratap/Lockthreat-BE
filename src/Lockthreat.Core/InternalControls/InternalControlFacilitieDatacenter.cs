using Abp.Domain.Entities.Auditing;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.FacilitiesDatacenters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.InternalControls
{
 public   class InternalControlFacilitieDatacenter : FullAuditedEntity<long>
    {
        public long? InternalControlId { get; set; }
        public InternalControl InternalControl { get; set; }

        public long? FacilitieDatacenterId  { get; set; }
        public FacilitieDatacenter FacilitieDatacenter { get; set; }
    }
}
