using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using Lockthreat.GrcPrograms;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Projects 
{
    public class Project  : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public int? IndustryId { get; set; }
        public DynamicParameterValue Industry { get; set; }


        public string ProjectLogo { get; set; }


        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }

        public long? ParentProgramId { get; set; }

        public GrcProgram ParentProgram { get; set; }

        public string ProjectScope { get; set; }

        public long? ProjectSponsorId { get; set; }
        public Employee ProjectSponsor { get; set; }

        public long? ProjectDirectorId { get; set; }
        public Employee ProjectDirector { get; set; }

        public ICollection<ProjectCountries> SelectedCountries { get; set; }
        public ICollection<ProjectTeamMember> SelectedInternalTeams { get; set; }
        public ICollection<ProjectTeamMemberExternal> SelectedExternalTeams { get; set; }
        public ICollection<ProjectTeamMemberProject> SelectedTeams { get; set; }
        public List<ProjectAuthoratativeDocument> SelectedAuthProjDocuments { get; set; }
        public List<ProjectComponent> SelectedProjectComponents { get; set; }
    }
}
