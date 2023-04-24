using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.GrcPrograms
{
    [Table("ProgramTeams")]
    public  class ProgramTeam : FullAuditedEntity<long>
    {
        public long? GrcProgramId   { get; set; }
        public GrcProgram GrcProgram  { get; set; }

        public long? ProgramTeamsId  { get; set; }
        public Employee ProgramTeams  { get; set; }
    }
}
