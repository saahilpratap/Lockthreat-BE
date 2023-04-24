using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Lockthreat.AuthoratativeDocuments;
using Lockthreat.AuthoratativeDocument.Dto;
using Lockthreat.Countries;
using Lockthreat.OrganizationSetups;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.ProjectsInfo.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using Lockthreat.GRCPrograms;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.GrcPrograms;
using Lockthreat.Projects;
using Lockthreat.Common;

namespace Lockthreat.ProjectsInfo
{
    public class ProjectAppService : LockthreatAppServiceBase
    {
        private readonly IRepository<Project, long> _projectsDetailsRepository;
        private readonly IRepository<ProjectCountries, long> _projectCountriesRepository;
        private readonly IRepository<ProjectTeamMember, long> _ProjectTeamMemberInternalRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<AuthoratativeDocuments.AuthoratativeDocument, long> _authdocRepository;
        private readonly IRepository<ProjectAuthoratativeDocument, long> _projAuthdocRepository;
        private readonly IRepository<ProjectTeamMemberExternal, long> _projectTeamMemberExternalRepository;
        private readonly IRepository<ProjectTeamMemberProject, long> _projectTeamMemberRepository;
        private readonly IRepository<ProjectComponent, long> _projectComponentsRepository;
        private readonly IRepository<ProjectAudit, long> _ProjectAuditsRepository;
        private readonly IRepository<GrcProgram, long> _programRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        public ProjectAppService(IRepository<Project, long> projectsDetailsRepository,
            IRepository<ProjectCountries, long> projectCountriesRepository,
            IRepository<ProjectTeamMember, long> projectTeamMemberInternalRepository,
            IRepository<Employees.Employee, long> employessRepository, 
            IRepository<LockThreatOrganization, long> organizationSetupRepository,
            ICountriesAppservice countriesAppservice, 
            IRepository<AuthoratativeDocuments.AuthoratativeDocument, long> authdocRepository,
            IRepository<ProjectAuthoratativeDocument, long> projAuthdocRepository, 
            IRepository<ProjectTeamMemberExternal, long> projectTeamMemberExternalRepository, 
            IRepository<ProjectTeamMemberProject, long> projectTeamMemberRepository, 
            IRepository<ProjectComponent, long> projectComponentsRepository, 
            IRepository<ProjectAudit, long> projectAuditsRepository,
            IRepository<GrcProgram, long> programRepository, ICodeGeneratorCommonAppservice codegeneratorRepository)
        {
            _projectsDetailsRepository = projectsDetailsRepository;
            _projectCountriesRepository = projectCountriesRepository;
            _ProjectTeamMemberInternalRepository = projectTeamMemberInternalRepository;
            _employessRepository = employessRepository;
            _organizationSetupRepository = organizationSetupRepository;
            _countriesAppservice = countriesAppservice;
            _authdocRepository = authdocRepository;
            _projAuthdocRepository = projAuthdocRepository;
            _projectTeamMemberExternalRepository = projectTeamMemberExternalRepository;
            _projectTeamMemberRepository = projectTeamMemberRepository;
            _projectComponentsRepository = projectComponentsRepository;
            _ProjectAuditsRepository = projectAuditsRepository;
            _programRepository = programRepository;
            _codegeneratorRepository = codegeneratorRepository;
        }

        public string GetNextProjectId()
        {
            string nextProjectId = "";
            var projItem = _projectsDetailsRepository.GetAllList().LastOrDefault();
            if (projItem != null)
            {
                nextProjectId = "PROJ-" + (projItem.Id + 1);
            }
            else
            {
                nextProjectId = "PROJ-1";
            }

            return nextProjectId;
        }


        public async Task AddorEditProject(ProjectDto project)
        {
            try
            {
                if (string.IsNullOrEmpty(project.ProjectId))
                {
                    project.ProjectId = _codegeneratorRepository.GetNextId(LockthreatConsts.Project, "PROJ");
                }

                project.TenantId = AbpSession.TenantId;
                project.IndustryId = project.IndustryId == 0 ? null : project.IndustryId;
                project.LockThreatOrganizationId = project.LockThreatOrganizationId == 0 ? null : project.LockThreatOrganizationId;
                project.ParentProgramId = project.ParentProgramId == 0 ? null : project.ParentProgramId;

                if (project.Id > 0)
                {
                    if (project.RemovedAuthProjDocuments != null)
                    {
                        foreach (var ext in project.RemovedAuthProjDocuments)
                        {
                            bool exist = _projAuthdocRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveProjectAuthoratativeDocument(ext);
                            }
                        }
                    }

                    if (project.RemovedCountries != null)
                    {
                        foreach (var ext in project.RemovedCountries)
                        {
                            bool exist = _projectCountriesRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveProjectCountry(ext);
                            }
                        }
                    }

                    if (project.RemovedExternalTeams != null)
                    {
                        foreach (var ext in project.RemovedExternalTeams)
                        {
                            bool exist = _projectTeamMemberExternalRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveProjectTeamMemberExternal(ext);
                            }
                        }
                    }

                    if (project.RemovedInternalTeams != null)
                    {
                        foreach (var ext in project.RemovedInternalTeams)
                        {
                            bool exist = _ProjectTeamMemberInternalRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveProjectTeamMemberInternal(ext);
                            }
                        }
                    }

                    if (project.RemovedTeams != null)
                    {
                        foreach (var ext in project.RemovedTeams)
                        {
                            bool exist = _projectTeamMemberRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveProjectTeamMember(ext);
                            }
                        }
                    }

                    if (project.RemovedProjectComponents != null)
                    {
                        foreach (var ext in project.RemovedProjectComponents)
                        {
                            bool exist = _projectComponentsRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveProjectComponents(ext);
                            }
                        }
                    }
                }

                await _projectsDetailsRepository.InsertOrUpdateAsync(ObjectMapper.Map<Project>(project));
                if (project.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.Project, "PROJ");
                }
               

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<PagedResultDto<ProjectListDto>> GetAllProjects(ProjectListInput input)
        {
            try
            {
                IQueryable<Project> query;
                if (input.IsLoggedInUserProjects)
                {
                    query = _projectsDetailsRepository.GetAll().Include(p => p.ProjectSponsor).
                    ThenInclude(p => p.LockThreatOrganization).Include(p => p.ProjectDirector).ThenInclude(p => p.LockThreatOrganization)
                    .Include(p => p.LockThreatOrganization).Include(p => p.ParentProgram).Include(p => p.SelectedExternalTeams)
                    .Include(p => p.SelectedInternalTeams).Include(p => p.SelectedTeams)
                    .Where(p => p.ProjectSponsorId == AbpSession.UserId || p.ProjectDirectorId == AbpSession.UserId
                        || p.SelectedTeams.Any(t => t.TeamMembersId == AbpSession.UserId) ||
                        p.SelectedExternalTeams.Any(t => t.TeamMembersExternalId == AbpSession.UserId) ||
                        p.SelectedInternalTeams.Any(t => t.TeamMembersInternalId == AbpSession.UserId))
                    .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    u =>
                        u.ProjectId.Contains(input.Filter) ||
                        u.ProjectName.Contains(input.Filter) ||
                        u.ProjectSponsor.Name.Contains(input.Filter) ||
                        u.ProjectDirector.Name.Contains(input.Filter) ||
                        u.LockThreatOrganization.CompanyName.Contains(input.Filter) ||
                        u.ProjectDirector.EmployeePosition.Contains(input.Filter) ||
                        u.ProjectSponsor.EmployeePosition.Contains(input.Filter) ||
                        u.ParentProgram.ProgramTitle.Contains(input.Filter));
                }
                else
                {
                    query = _projectsDetailsRepository.GetAll().Include(p => p.ProjectSponsor).
                    ThenInclude(p => p.LockThreatOrganization).Include(p => p.ProjectDirector).ThenInclude(p => p.LockThreatOrganization)
                    .Include(p => p.LockThreatOrganization).Include(p => p.ParentProgram)
                    .WhereIf(
                    !input.Filter.IsNullOrWhiteSpace(),
                    u =>
                        u.ProjectId.Contains(input.Filter) ||
                        u.ProjectName.Contains(input.Filter) ||
                        u.ProjectSponsor.Name.Contains(input.Filter) ||
                        u.ProjectDirector.Name.Contains(input.Filter) ||
                        u.LockThreatOrganization.CompanyName.Contains(input.Filter) ||
                        u.ProjectDirector.EmployeePosition.Contains(input.Filter) ||
                        u.ProjectSponsor.EmployeePosition.Contains(input.Filter) ||
                        u.ParentProgram.ProgramTitle.Contains(input.Filter));
                }

                var projects = await (from q in query
                                      select new ProjectListDto
                                      {
                                          Id = q.Id,
                                          ProjectId = q.ProjectId,
                                          ProjectName = q.ProjectName,
                                          SponserName = q.ProjectSponsor.Name,
                                          SponserPosition = q.ProjectSponsor.EmployeePosition,
                                          SponserCompany = q.ProjectSponsor.LockThreatOrganization.CompanyName,
                                          DirectorName = q.ProjectDirector.Name,
                                          DirectorPosition = q.ProjectDirector.EmployeePosition,
                                          DirectorCompany = q.ProjectDirector.LockThreatOrganization.CompanyName,
                                          LockThreatOrganization = q.LockThreatOrganization.CompanyName,
                                          ParentProgramName = q.ParentProgram.ProgramTitle
                                      }).OrderBy(input.Sorting).PageBy(input).ToListAsync();

                var projectsCount = await query.CountAsync();

                return new PagedResultDto<ProjectListDto>(
                    projectsCount,
                    projects
                    );
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ProjectDto> GetProjectInfo(long? projectId)
        {
            try
            {
                ProjectDto projects  = new ProjectDto();
                 Project projectInfoById = new Project();
                if (projectId > 0)
                {
                    projectInfoById = await _projectsDetailsRepository.GetAll().Include(p => p.ParentProgram).Include(p => p.Industry).FirstOrDefaultAsync(p => p.Id == projectId);
                }
                if (projectInfoById.Id > 0)
                {
                    projects = ObjectMapper.Map<ProjectDto>(projectInfoById);
                    projects.SelectedCountries = ObjectMapper.Map<List<ProjectCountriesDto>>(await _projectCountriesRepository.GetAll().Where(p => p.ProjectId == projectId).ToListAsync());
                    projects.SelectedTeams = ObjectMapper.Map<List<ProjectTeamMemberDto>>(await _projectTeamMemberRepository.GetAll().Where(p => p.ProjectId == projectId).ToListAsync());
                    projects.SelectedInternalTeams = ObjectMapper.Map<List<ProjectTeamMemberInternalDto>>(await _ProjectTeamMemberInternalRepository.GetAll().Where(p => p.ProjectId == projectId).ToListAsync());
                    projects.SelectedExternalTeams = ObjectMapper.Map<List<ProjectTeamMemberExternalDto>>(await _projectTeamMemberExternalRepository.GetAll().Where(p => p.ProjectId == projectId).ToListAsync());
                    projects.SelectedAuthProjDocuments = ObjectMapper.Map<List<ProjectAuthoratativeDocumentDto>>(await _projAuthdocRepository.GetAll().Where(p => p.ProjectId == projectId).ToListAsync());
                    projects.SelectedProjectComponents = ObjectMapper.Map<List<ProjectComponentsDto>>(await _projectComponentsRepository.GetAll().Where(p => p.ProjectId == projectId).ToListAsync());
                }

                projects.ParentProgramsList = ObjectMapper.Map<List<ProgramDto>>(await _programRepository.GetAll().Include(p => p.SelectedProgramTeams).Include(p => p.SelectedProgramCoordinators).ToListAsync());
                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                projects.ProjectDirectors = ObjectMapper.Map<List<ProjectUser>>(employees);
                projects.ProjectSponsors = ObjectMapper.Map<List<ProjectUser>>(employees);
                projects.ProjectTeamMembers = ObjectMapper.Map<List<ProjectUser>>(employees);
                projects.ProjectTeamMembersExternal = ObjectMapper.Map<List<ProjectUser>>(employees);
                projects.ProjectTeamMembersInternal = ObjectMapper.Map<List<ProjectUser>>(employees);
                projects.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                projects.AuthoratativeDocuments = ObjectMapper.Map<List<AuthoratativeDocumentsDto>>(await _authdocRepository.GetAll().ToListAsync());
                projects.ProjectIndustries = await _countriesAppservice.GetIndustrySectors();
                projects.ProjectComponents = await _countriesAppservice.GetComponents();
                projects.Countries = await _countriesAppservice.GetAll();


                return projects;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveProject(long projectId)
        {
            try
            {
                var project = await _projectsDetailsRepository.GetAll().Where(p => p.Id == projectId).Include(p => p.SelectedAuthProjDocuments)
                    .Include(p => p.SelectedCountries).Include(p => p.SelectedExternalTeams).Include(p => p.SelectedInternalTeams)
                    .Include(p => p.SelectedProjectComponents).Include(p => p.SelectedTeams).FirstOrDefaultAsync();

                if (project.SelectedAuthProjDocuments.Count > 0)
                {
                    foreach (var item in project.SelectedAuthProjDocuments)
                    {
                        await RemoveProjectAuthoratativeDocument(item.Id);
                    }
                }

                if (project.SelectedCountries.Count > 0)
                {
                    foreach (var item in project.SelectedCountries)
                    {
                        await RemoveProjectCountry(item.Id);
                    }
                }

                if (project.SelectedExternalTeams.Count > 0)
                {
                    foreach (var item in project.SelectedExternalTeams)
                    {
                        await RemoveProjectTeamMemberExternal(item.Id);
                    }
                }

                if (project.SelectedInternalTeams.Count > 0)
                {
                    foreach (var item in project.SelectedInternalTeams)
                    {
                        await RemoveProjectTeamMemberInternal(item.Id);
                    }
                }

                if (project.SelectedProjectComponents.Count > 0)
                {
                    foreach (var item in project.SelectedProjectComponents)
                    {
                        await RemoveProjectComponents(item.Id);
                    }
                }

                if (project.SelectedTeams.Count > 0)
                {
                    foreach (var item in project.SelectedTeams)
                    {
                        await RemoveProjectTeamMember(item.Id);
                    }
                }

                await _projectsDetailsRepository.DeleteAsync(project);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task RemoveProjectAuthoratativeDocument(long id)
        {
            try
            {
                var authDoc = await _projAuthdocRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _projAuthdocRepository.DeleteAsync(authDoc);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveProjectCountry(long id)
        {
            try
            {
                var country = await _projectCountriesRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _projectCountriesRepository.DeleteAsync(country);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveProjectTeamMember(long id)
        {
            try
            {
                var member = await _projectTeamMemberRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _projectTeamMemberRepository.DeleteAsync(member);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveProjectTeamMemberExternal(long id)
        {
            try
            {
                var member = await _projectTeamMemberExternalRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _projectTeamMemberExternalRepository.DeleteAsync(member);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveProjectTeamMemberInternal(long id)
        {
            try
            {
                var member = await _ProjectTeamMemberInternalRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _ProjectTeamMemberInternalRepository.DeleteAsync(member);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveProjectComponents(long id)
        {
            try
            {
                var component = await _projectComponentsRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _projectComponentsRepository.DeleteAsync(component);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
