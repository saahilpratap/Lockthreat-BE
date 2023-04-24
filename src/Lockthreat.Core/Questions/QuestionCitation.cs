using Abp.Domain.Entities.Auditing;
using Lockthreat.Citations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Questions 
{
  public  class QuestionCitation : FullAuditedEntity<long>
    {
        public long? QuestionId  { get; set; }

        public Question Question { get; set; }

        public long? CitationId { get; set; }
        public Citation Citation { get; set; }

        
    }
}
