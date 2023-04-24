using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.GRCPrograms.Dto
{
    public class ProgramAuthoritativeDocumentsDto : FullAuditedEntity<long>
    {
        public long? GrcProgramId { get; set; }
        public long? AuthoratativeDocumentId  { get; set; }
    }
}
