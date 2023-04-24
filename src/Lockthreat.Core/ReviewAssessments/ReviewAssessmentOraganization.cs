using Abp.Domain.Entities.Auditing;
using Lockthreat.OrganizationSetups;
using Lockthreat.ReviewAssessments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ReviewsAssessments
{
  public  class ReviewAssessmentOraganization  : FullAuditedEntity<long>
    {
        public long? ReviewAssessmentId  { get; set; }
        public ReviewAssessment ReviewAssessment { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization { get; set; }
    }
}
