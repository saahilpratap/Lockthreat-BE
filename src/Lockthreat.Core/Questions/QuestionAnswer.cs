using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Questions 
{
  public  class QuestionAnswer : FullAuditedEntity<long>
    {
        public long? QuestionId  { get; set; }
        public Question Question  { get; set; }
        public bool CorrectAnswer { get; set; }
        public int? SrNo { get; set; }

        public string Option { get; set; }

        public int? Points { get; set; }

    }
}
