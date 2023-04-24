using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocuments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Questions 
{
  public  class QuestionAuthoratativeDocument : FullAuditedEntity<long>
    {
        public long? AuthoratativeDocumentId { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }

        public long? QuestionId  { get; set; }
        public Question Question { get; set; }


    }
}
