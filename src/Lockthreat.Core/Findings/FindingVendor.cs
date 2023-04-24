using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Findings 
{
 public   class FindingVendor : FullAuditedEntity<long>
    {
        public long? FindingId  { get; set; }
        public Finding Finding { get; set; }

        public long? VendorId { get; set; }
        public Vendor Vendor { get; set; }

    }
}
