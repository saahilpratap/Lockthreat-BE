using Abp.Domain.Entities.Auditing;
using Lockthreat.GrcPrograms;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.AuthoratativeDocuments 
{
   public class AuthoratativeDocumentProgram : FullAuditedEntity<long>
    {

        public long? AuthoratativeDocumentId  { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }
        public long? GrcProgramId  { get; set; }
        public GrcProgram GrcProgram { get; set; }
        
    }
}
