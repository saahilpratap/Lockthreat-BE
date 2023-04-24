using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.DynamicEntityParameters;
using Abp.Extensions;
using Abp.Linq.Extensions;
using Lockthreat.AuthoratativeDocuments;
using Lockthreat.AuthoratativeDocument.Dto;
using Lockthreat.Countries;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.OrganizationSetup;
using Lockthreat.OrganizationSetup.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using Lockthreat.Employees;
using System.Threading.Tasks;
using Lockthreat.OrganizationSetups;
using Lockthreat.GrcPrograms;
using Lockthreat.Common;

namespace Lockthreat.GRCPrograms
{
    public class ProgramAppService : LockthreatAppServiceBase
    {
        private readonly IRepository<GrcProgram, long> _programRepository;
        private readonly IRepository<ProgramTeam, long> _programTeamRepository;
        private readonly IRepository<ProgramCoordinator, long> _programCoordinatorsRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<AuthoratativeDocuments.AuthoratativeDocument, long> _authdocRepository;
        private readonly IRepository<ProgramAuthoritativeDocument, long> _progAuthdocRepository;
        private readonly IRepository<ProgramCountry, long> _programCountriesRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        public ProgramAppService(IRepository<GrcProgram, long> programRepository,
            IRepository<ProgramTeam, long> programTeamRepository,
            IRepository<ProgramCoordinator, long> programCoordinatorsRepository,
            IRepository<Employees.Employee, long> employessRepository,
            IRepository<LockThreatOrganization, long> organizationSetupRepository, ICountriesAppservice countriesAppservice,
            IRepository<AuthoratativeDocuments.AuthoratativeDocument, long> authdocRepository,
            IRepository<ProgramAuthoritativeDocument, long> progAuthdocRepository,
            IRepository<ProgramCountry, long> programCountriesRepository, ICodeGeneratorCommonAppservice codegeneratorRepository)
        {
            _programRepository = programRepository;
            _programTeamRepository = programTeamRepository;
            _programCoordinatorsRepository = programCoordinatorsRepository;
            _employessRepository = employessRepository;
            _organizationSetupRepository = organizationSetupRepository;
            _countriesAppservice = countriesAppservice;
            _authdocRepository = authdocRepository;
            _progAuthdocRepository = progAuthdocRepository;
            _programCountriesRepository = programCountriesRepository;
            _codegeneratorRepository = codegeneratorRepository;
        }

        public async Task<ProgramDto> GetProgramInfo(long? programId)
        {
            try
            {
                ProgramDto program = new ProgramDto();
                GrcProgram programInfoById = new GrcProgram();
                if (programId > 0)
                {
                    programInfoById = await _programRepository.GetAll().FirstOrDefaultAsync(p => p.Id == programId);
                }
                if (programInfoById.Id > 0)
                {
                    program = ObjectMapper.Map<ProgramDto>(programInfoById);
                    program.SelectedCountries = ObjectMapper.Map<List<ProgramCountriesDto>>(await _programCountriesRepository.GetAll().Where(p => p.GrcProgramId == programInfoById.Id).ToListAsync());
                    program.SelectedProgramTeams = ObjectMapper.Map<List<ProgramTeamDto>>(await _programTeamRepository.GetAll().Where(p => p.GrcProgramId == programInfoById.Id).ToListAsync());
                    program.SelectedProgramCoordinators = ObjectMapper.Map<List<ProgramCoordinatorDto>>(await _programCoordinatorsRepository.GetAll().Where(p => p.GrcProgramId == programInfoById.Id).ToListAsync());
                    program.SelectedProgramAuthoritativeDocuments = ObjectMapper.Map<List<ProgramAuthoritativeDocumentsDto>>(await _progAuthdocRepository.GetAll().Where(p => p.GrcProgramId == programInfoById.Id).ToListAsync());
                }

                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                program.ProgramDirectors = ObjectMapper.Map<List<ProgramUser>>(employees);
                program.ProgramSponsors = ObjectMapper.Map<List<ProgramUser>>(employees);
                program.ProgramTeams = ObjectMapper.Map<List<ProgramUser>>(employees);
                program.ProgramCoordinators = ObjectMapper.Map<List<ProgramUser>>(employees);
                program.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                program.Countries = await _countriesAppservice.GetAll();
                program.AuthoratativeDocuments = ObjectMapper.Map<List<AuthoratativeDocumentsDto>>(await _authdocRepository.GetAll().ToListAsync());
                var employessData = employees.GroupBy(e => e.LockThreatOrganization.CompanyName);
                return program;


            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task AddorEditProgram(ProgramDto program)
        {
            try
            {
                if (string.IsNullOrEmpty(program.ProgramId))
                {
                    program.ProgramId = _codegeneratorRepository.GetNextId(LockthreatConsts.Program, "PROG"); 
                }

                program.TenantId = AbpSession.TenantId;

                if (program.Id > 0)
                {
                    if (program.RemovedProgramTeams != null)
                    {
                        foreach (var ext in program.RemovedProgramTeams)
                        {
                            bool exist = _programTeamRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveProgramTeamMember(ext);
                            }
                        }
                    }

                    if (program.RemovedProgramCoordinators != null)
                    {
                        foreach (var ext in program.RemovedProgramCoordinators)
                        {
                            bool exist = _programCoordinatorsRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveProgramCoordinator(ext);
                            }
                        }
                    }

                    if (program.RemovedProgramAuthDocs != null)
                    {
                        foreach (var ext in program.RemovedProgramAuthDocs)
                        {
                            bool exist = _progAuthdocRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveProgramAuthoratativeDocument(ext);
                            }
                        }
                    }

                    if (program.RemovedCountries != null)
                    {
                        foreach (var ext in program.RemovedCountries)
                        {
                            bool exist = _programCountriesRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveProgramCountry(ext);
                            }
                        }
                    }
                }

                await _programRepository.InsertOrUpdateAsync(ObjectMapper.Map<GrcProgram>(program));
                if (program.Id == 0)
                {
                   await _codegeneratorRepository.CodeCreate(LockthreatConsts.Program, "PROG");
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public string GetNextPrgramId()
        {
            string nextProjectId = "";
            var projItem = _programRepository.GetAllList().LastOrDefault();
            if (projItem != null)
            {
                nextProjectId = "PROG-" + (projItem.Id + 1);
            }
            else
            {
                nextProjectId = "PROG-1";
            }

            return nextProjectId;
        }

        public async Task RemoveProgramTeamMember(long id)
        {
            try
            {
                var employee = await _programTeamRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _programTeamRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveProgramCoordinator(long id)
        {
            try
            {
                var employee = await _programCoordinatorsRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _programCoordinatorsRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveProgram(long programId)
        {
            try
            {
                var program = await _programRepository.GetAll().Where(p => p.Id == programId).Include(p => p.SelectedProgramTeams).Include(p => p.SelectedProgramCoordinators).Include(p => p.SelectedProgramAuthoritativeDocuments).FirstOrDefaultAsync();

                if (program.SelectedProgramTeams.Count > 0)
                {
                    foreach (var item in program.SelectedProgramTeams)
                    {
                        await RemoveProgramTeamMember(item.Id);
                    }
                }

                if (program.SelectedProgramCoordinators.Count > 0)
                {
                    foreach (var item in program.SelectedProgramCoordinators)
                    {
                        await RemoveProgramCoordinator(item.Id);
                    }
                }

                if (program.SelectedProgramAuthoritativeDocuments.Count > 0)
                {
                    foreach (var item in program.SelectedProgramAuthoritativeDocuments)
                    {
                        await RemoveProgramAuthoratativeDocument(item.Id);
                    }
                }

                await _programRepository.DeleteAsync(program);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveProgramAuthoratativeDocument(long id)
        {
            try
            {
                var document = await _progAuthdocRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _progAuthdocRepository.DeleteAsync(document);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveProgramCountry(long id)
        {
            try
            {
                var country = await _programCountriesRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _programCountriesRepository.DeleteAsync(country);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<PagedResultDto<ProgramListDto>> GetAllPrograms(ProgramListInput input)
        {
            try
            {
                IQueryable<GrcProgram> query;
                if (input.IsLoggedInUserPrograms)
                {
                    query = _programRepository.GetAll()
                        .Include(p => p.ProgramSponsor).ThenInclude(p => p.LockThreatOrganization)
                        .Include(p => p.ProgramDirector).ThenInclude(p => p.LockThreatOrganization).Include(p => p.LockThreatOrganization)
                        .Include(p => p.SelectedProgramTeams).Include(p => p.SelectedProgramCoordinators)
                        .Where(p => p.ProgramDirectorId == AbpSession.UserId || p.ProgramSponsorId == AbpSession.UserId
                        || p.SelectedProgramTeams.Any(t => t.ProgramTeamsId == AbpSession.UserId) ||
                        p.SelectedProgramTeams.Any(t => t.ProgramTeamsId == AbpSession.UserId))
                        .WhereIf(
                        !input.Filter.IsNullOrWhiteSpace(),
                        u =>
                            u.ProgramId.Contains(input.Filter) ||
                            u.ProgramTitle.Contains(input.Filter) ||
                            u.ProgramSponsor.Name.Contains(input.Filter) ||
                            u.ProgramDirector.Name.Contains(input.Filter) ||
                            u.LockThreatOrganization.CompanyName.Contains(input.Filter) ||
                            u.ProgramDirector.EmployeePosition.Contains(input.Filter) ||
                            u.ProgramSponsor.EmployeePosition.Contains(input.Filter)
                    );
                }
                else
                {
                    query = _programRepository.GetAll().Include(p => p.ProgramSponsor).ThenInclude(p => p.LockThreatOrganization).Include(p => p.ProgramDirector).ThenInclude(p => p.LockThreatOrganization).Include(p => p.LockThreatOrganization)
                        .WhereIf(
                        !input.Filter.IsNullOrWhiteSpace(),
                        u =>
                            u.ProgramId.Contains(input.Filter) ||
                            u.ProgramTitle.Contains(input.Filter) ||
                            u.ProgramSponsor.Name.Contains(input.Filter) ||
                            u.ProgramDirector.Name.Contains(input.Filter) ||
                            u.LockThreatOrganization.CompanyName.Contains(input.Filter) ||
                            u.ProgramDirector.EmployeePosition.Contains(input.Filter) ||
                            u.ProgramSponsor.EmployeePosition.Contains(input.Filter)
                    );
                }


                //var programs = ObjectMapper.Map<List<ProgramListDto>>(query);

                var programs = await (from q in query
                                      select new ProgramListDto
                                      {
                                          Id = q.Id,
                                          ProgramId = q.ProgramId,
                                          ProgramTitle = q.ProgramTitle,
                                          SponserName = q.ProgramSponsor.Name,
                                          SponserPosition = q.ProgramSponsor.EmployeePosition,
                                          SponserCompany = q.ProgramSponsor.LockThreatOrganization.CompanyName,
                                          DirectorName = q.ProgramDirector.Name,
                                          DirectorPosition = q.ProgramDirector.EmployeePosition,
                                          DirectorCompany = q.ProgramDirector.LockThreatOrganization.CompanyName,
                                          CompanyName = q.LockThreatOrganization.CompanyName
                                      }).OrderBy(input.Sorting).PageBy(input).ToListAsync();

                var programsCount = await query.CountAsync();

                return new PagedResultDto<ProgramListDto>(
                    programsCount,
                    programs
                    );
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
