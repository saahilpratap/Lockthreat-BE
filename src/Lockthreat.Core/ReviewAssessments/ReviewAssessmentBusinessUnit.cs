using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ReviewAssessments 
{
public  class ReviewAssessmentBusinessUnit : FullAuditedEntity<long>
    {
        public long? ReviewAssessmentId  { get; set; }
        public ReviewAssessment ReviewAssessment  { get; set; }

        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
    }
}
