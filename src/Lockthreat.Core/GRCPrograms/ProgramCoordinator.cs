using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.GrcPrograms 
{

    [Table("ProgramCoordinators")]
    public class ProgramCoordinator  : FullAuditedEntity<long>
    {
        public long? GrcProgramId  { get; set; }
        public GrcProgram GrcProgram { get; set; }

        public long? ProgramCoordinatorsId  { get; set; }
        public Employee ProgramCoordinators   { get; set; }
    }
}
