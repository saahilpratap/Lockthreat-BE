using Abp.Domain.Entities.Auditing;
using Lockthreat.Questions;
using Lockthreat.ReviewDatas;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Questions 
{
  public  class QuestionReviewData : FullAuditedEntity<long>
    {
        public long? ReviewDataId { get; set; }
        public ReviewData ReviewData { get; set; }

        public long? QuestionId  { get; set; }

        public Question Question  { get; set; }
    }
}
