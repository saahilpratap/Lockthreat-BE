using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lockthreat.GrcPrograms 
{
    [Table("ProgramCountrys")]
    public class ProgramCountry  : FullAuditedEntity<long>
    {
        public long? GrcProgramId  { get; set; }

        public GrcProgram GrcProgram { get; set; }

        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }
    }
}
