using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;

using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.GrcPrograms 
{
    [Table("GrcPrograms")]
    public class GrcProgram  : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string ProgramId { get; set; }

        public string ProgramTitle { get; set; }

        public string ProgramTeamEmail { get; set; }

        public DateTime? StartDate { get; set; }

        public string Description { get; set; }

        public string ProgramLogo { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }
     
        public long? ProgramSponsorId { get; set; }
        public Employee ProgramSponsor { get; set; }

        public long? ProgramDirectorId { get; set; }
        public Employee ProgramDirector { get; set; }

        public ICollection<ProgramCountry> SelectedCountries { get; set; }

        public ICollection<ProgramTeam> SelectedProgramTeams { get; set; }

        public ICollection<ProgramCoordinator> SelectedProgramCoordinators { get; set; }

        public ICollection<ProgramAuthoritativeDocument> SelectedProgramAuthoritativeDocuments { get; set; }

    }
}
