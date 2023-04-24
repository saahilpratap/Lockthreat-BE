using Abp.Domain.Entities.Auditing;
using Lockthreat.Questions;
using Lockthreat.ReviewAssessments;
using Lockthreat.ReviewsAssessments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Questions 
{
  public class QuestionReviewAssessment : FullAuditedEntity<long>
    {
        public long? QuestionId  { get; set; }
        public Question Question { get; set; }

        public long? ReviewAssessmentId  { get; set; }
        public ReviewAssessment ReviewAssessment  { get; set; }

    }
}
