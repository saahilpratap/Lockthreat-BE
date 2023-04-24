using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocument.Dto;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.Employee.Dto;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ProjectsInfo.Dto
{
    public class ProjectDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }

        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public int? IndustryId { get; set; }

        public string ProjectLogo { get; set; }

        public long? LockThreatOrganizationId  { get; set; }

        public List<GetOrganizationDto> CompanyLists { get; set; }

        public List<CountryDto> Countries { get; set; }

        public long? ParentProgramId { get; set; }
        public List<ProgramDto> ParentProgramsList { get; set; }

        public string ProjectScope { get; set; }

        public long? ProjectSponsorId { get; set; }
        public EmployeeDto ProjectSponsor { get; set; }

        public long? ProjectDirectorId { get; set; }
        public EmployeeDto ProjectDirector { get; set; }

        public List<ProjectUser> ProjectTeamMembersInternal { get; set; }

        public List<ProjectUser> ProjectTeamMembersExternal { get; set; }

        public List<ProjectUser> ProjectDirectors { get; set; }

        public List<ProjectUser> ProjectSponsors { get; set; }

        public List<ProjectUser> ProjectTeamMembers { get; set; }

        public List<AuthoratativeDocumentsDto> AuthoratativeDocuments { get; set; }

        public List<ProjectCountriesDto> SelectedCountries { get; set; }

        public List<long> RemovedCountries { get; set; }
        public List<ProjectTeamMemberInternalDto> SelectedInternalTeams { get; set; }
        public List<long> RemovedInternalTeams { get; set; }


        public List<ProjectTeamMemberExternalDto> SelectedExternalTeams { get; set; }
        public List<long> RemovedExternalTeams { get; set; }


        public List<ProjectTeamMemberDto> SelectedTeams { get; set; }

        public List<long> RemovedTeams { get; set; }

        public List<ProjectAuthoratativeDocumentDto> SelectedAuthProjDocuments { get; set; }

        public List<long> RemovedAuthProjDocuments { get; set; }

        public List<ProjectComponentsDto> SelectedProjectComponents { get; set; }

        public List<long> RemovedProjectComponents { get; set; }

        public List<DynamicNameValueDto> ProjectComponents { get; set; }

        public List<DynamicNameValueDto> ProjectIndustries { get; set; }



    }

    public class ProjectCountriesDto
    {
        public long Id { get; set; }

        public long ProjectId  { get; set; }

        public int CountryId { get; set; }
    }

    public class ProjectTeamMemberInternalDto
    {
        public long Id { get; set; }
        public long ProjectId  { get; set; }
        public long TeamMembersInternalId { get; set; }
    }

    public class ProjectTeamMemberExternalDto
    {
        public long Id { get; set; }
        public long ProjectId  { get; set; }
        public long TeamMembersExternalId { get; set; }
    }


    public class ProjectTeamMemberDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }
        public long TeamMembersId { get; set; }
    }

    public class ProjectAuthoratativeDocumentDto
    {
        public long Id { get; set; }
        public long ProjectId { get; set; }

        public long AuthoratativeDocumentId { get; set; }

    }

    public class ProjectComponentsDto
    {
        public long Id { get; set; }

        public long? ProjectId  { get; set; }

        public int? ProjectComponentId { get; set; }
    }
}
