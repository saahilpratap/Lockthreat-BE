using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Questions 
{
  public  class QuestionTarget : FullAuditedEntity<long>
    {
        public long? QuestionId  { get; set; }
        public Question Question { get; set; }

        public int? QuestionTargetsId { get; set; }
        public DynamicParameterValue QuestionTargets  { get; set; }
    }
}
