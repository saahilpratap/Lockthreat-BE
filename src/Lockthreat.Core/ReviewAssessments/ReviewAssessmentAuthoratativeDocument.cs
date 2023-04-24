using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocuments;
using Lockthreat.ReviewAssessments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ReviewsAssessments
{
   public class ReviewAssessmentAuthoratativeDocument : FullAuditedEntity<long>
    {

        public long? ReviewAssessmentsId { get; set; }
        public ReviewAssessment ReviewAssessment  { get; set; }

        public long? AuthoratativeDocumentId { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }
    }
}
