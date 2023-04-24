using Abp.Domain.Entities.Auditing;
using Lockthreat.Questions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.AuthoratativeDocuments 
{
   public class AuthoratativeDocumentQuestion : FullAuditedEntity<long>
    {
        public long? AuthoratativeDocumentId  { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }

        public long? QuestionId  { get; set; }
        public Question Question { get; set; }


    }
}
