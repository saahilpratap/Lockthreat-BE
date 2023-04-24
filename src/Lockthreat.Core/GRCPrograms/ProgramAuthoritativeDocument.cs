using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocuments;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lockthreat.GrcPrograms 
{
    [Table("ProgramAuthoritativeDocuments")]
    public  class ProgramAuthoritativeDocument  : FullAuditedEntity<long>
    {
        public long? GrcProgramId  { get; set; }
        public GrcProgram GrcProgram { get; set; }
        public long? AuthoratativeDocumentId  { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }

    }
}
