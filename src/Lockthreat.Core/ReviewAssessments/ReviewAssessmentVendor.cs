using Abp.Domain.Entities.Auditing;
using Lockthreat.ReviewAssessments;
using Lockthreat.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ReviewAssessments 
{
 public  class ReviewAssessmentVendor: FullAuditedEntity<long>
    {
        public long? ReviewAssessmentId  { get; set; }
        public ReviewAssessment ReviewAssessment  { get; set; }

        public long? VendorId  { get; set; }
        public Vendor Vendor { get; set; }


    }
}
