using Abp.Domain.Entities.Auditing;
using Lockthreat.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Citations 
{
  public  class CitationQuestion  : FullAuditedEntity<long>
    {
        public long? CitationId  { get; set; }
        public Citation Citation { get; set; }

        public long? QuestionId  { get; set; }

        public Question Question { get; set; }

    }
}
