using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.AuthoratativeDocument.Dto;
using Lockthreat.Countries.Dto;
using Lockthreat.Employee.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.GRCPrograms.Dto
{
    public class ProgramDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }

        public string ProgramId { get; set; }

        public string ProgramTitle { get; set; }

        public string ProgramTeamEmail { get; set; }

        public DateTime? StartDate { get; set; }

        public string Description { get; set; }

        public string ProgramLogo { get; set; }

        public long? LockThreatOrganizationId  { get; set; }

        public List<GetOrganizationDto> CompanyLists { get; set; }

        public int? CountryId { get; set; }
        public List<CountryDto> Countries { get; set; }

        public long? ProgramSponsorId { get; set; }

        public List<ProgramUser> ProgramSponsors { get; set; }

        public long? ProgramDirectorId { get; set; }


        public List<ProgramUser> ProgramDirectors { get; set; }

        public List<ProgramTeamDto> SelectedProgramTeams { get; set; }
        public List<long> RemovedProgramTeams { get; set; }


        public List<ProgramCoordinatorDto> SelectedProgramCoordinators { get; set; }
        public List<long> RemovedProgramCoordinators { get; set; }


        //public List<ProgramsTeamsDto> AllEmployees { get; set; }

        public List<ProgramUser> ProgramTeams { get; set; }

        public List<ProgramUser> ProgramCoordinators { get; set; }

        public List<ProgramAuthoritativeDocumentsDto> SelectedProgramAuthoritativeDocuments { get; set; }

        public List<long> RemovedProgramAuthDocs { get; set; }


        public List<AuthoratativeDocumentsDto> AuthoratativeDocuments { get; set; }

        public List<ProgramCountriesDto> SelectedCountries { get; set; }
         
        public List<long> RemovedCountries { get; set; }
    }

    //public class ProgramsTeamsDto
    //{
    //    public string CompanyName { get; set; }

    //    public List<EmployeeListDto> ProgramTeams { get; set; }

    //}

    public class ProgramTeamDto
    {
        public long Id { get; set; }
        public long? GrcProgramId { get; set; }
        public long? ProgramTeamsId { get; set; }
    }

    public class ProgramCoordinatorDto
    {
        public long Id { get; set; }
        public long? GrcProgramId { get; set; }
        public long? ProgramCoordinatorsId { get; set; }
    }

    public class ProgramCountriesDto
    {
        public long Id { get; set; }

        public long ProjectId  { get; set; }

        public int CountryId { get; set; }
    }
}
