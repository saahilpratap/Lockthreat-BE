using Abp.Domain.Entities.Auditing;
using Lockthreat.ControlStandards;
using Lockthreat.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Questions 
{
 public  class QuestionControlStandard : FullAuditedEntity<long>
    {
        public long? QuestionId  { get; set; }
        public Question Question { get; set; }

        public long? ControlStandardId { get; set; }
        public ControlStandard ControlStandard { get; set; }
    }
}
