using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Lockthreat.OrganizationSetups;
using Lockthreat.StrategicObjectives.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Abp.UI;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.Common;
using Lockthreat.Countries;

using Lockthreat.AuthoratativeDocument.Dto;

namespace Lockthreat.StrategicObjectives
{
  public  class StrategicObjectivesAppService : LockthreatAppServiceBase, IStrategicObjectivesAppService
    {
                   
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly IRepository<StrategicObjective, long> _strategicObjectiveRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        public StrategicObjectivesAppService(IRepository<LockThreatOrganization, long> organizationSetupRepository,
            IRepository<StrategicObjective, long> strategicObjectiveRepository, ICountriesAppservice countriesAppservice, 
            ICodeGeneratorCommonAppservice codegeneratorRepository, IRepository<Employees.Employee, long> employessRepository)        
        {
            _organizationSetupRepository = organizationSetupRepository;
            _strategicObjectiveRepository = strategicObjectiveRepository;
            _codegeneratorRepository = codegeneratorRepository;
            _countriesAppservice = countriesAppservice;
            _employessRepository = employessRepository;

        }

        public async Task<StrategicObjectiveDto> GetStrategicObjectiveInfo (long? StrategicObjectiveId)
        {
            try
            {
                   StrategicObjectiveDto Strategic = new StrategicObjectiveDto();
                   StrategicObjective StrategicObjectiveById  = new StrategicObjective();
                   if (StrategicObjectiveId > 0)
                {
                    StrategicObjectiveById = await _strategicObjectiveRepository.GetAll().FirstOrDefaultAsync(p => p.Id == StrategicObjectiveId);
                    if (StrategicObjectiveById != null)
                    {
                        if (StrategicObjectiveById.Id > 0)
                        {
                            Strategic = ObjectMapper.Map<StrategicObjectiveDto>(StrategicObjectiveById);

                        }
                    }
                }               
                    var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                    Strategic.ExecutiveSponsors = ObjectMapper.Map<List<ProgramUser>>(employees);
                    Strategic.LockThreatOrganizations = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                    Strategic.Goals = await GetAllGoal();
                    Strategic.Types = await _countriesAppservice.GetAllStrategicType();
                    Strategic.Statuses = await _countriesAppservice.GetAllStrategicStatus();
                    return Strategic;                
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public async Task<List<OranizationGoalDto>> GetAllGoal()
        {
            var goals = new List<OranizationGoalDto>();
            var goal =( _strategicObjectiveRepository.GetAll().Where(x=>x.Goal!=null).Select(x => new OranizationGoalDto { Goal = x.Goal, Id = x.Id, LockThreatOrganizationId = x.LockThreatOrganizationId })).Distinct();

            if (goal.Count() != 0)
            {
                goals =  ObjectMapper.Map<List<OranizationGoalDto>>(goal);
            }
            return goals;
        }

        public async Task<PagedResultDto<StrategicObjectiveListDto>> GetAllStrategicObjectives (GetStrategicObjectiveInputDto input)
        {
            try
            {
                var query = _strategicObjectiveRepository.GetAllIncluding().Include(x => x.LockThreatOrganization).Include(y => y.ExecutiveSponsor).Include(z => z.Status)
                           
                             .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);


                var businessUnitCount = await query.CountAsync();

                var businessItems = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var strategicObjective = ObjectMapper.Map<List<StrategicObjectiveListDto>>(businessItems);

                return new PagedResultDto<StrategicObjectiveListDto>(
                   businessUnitCount,
                   strategicObjective
                   );
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task CreateOrUpdateStrategicObjectives (StrategicObjectiveDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.StrategicObjectiveId))
                {
                    input.StrategicObjectiveId = _codegeneratorRepository.GetNextId(LockthreatConsts.StrategicObjective,LockthreatConsts.SOB);
                }

                input.TenantId = AbpSession.TenantId;
               
                await _strategicObjectiveRepository.InsertOrUpdateAsync(ObjectMapper.Map<StrategicObjective>(input));
                if (input.Id == 0)
                {
                   await _codegeneratorRepository.CodeCreate(LockthreatConsts.StrategicObjective, LockthreatConsts.SOB);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public async Task DeleteStrategicObjective(EntityDto input)
        {
            try
            {
                var StrategicObjective = await _strategicObjectiveRepository.GetAsync(input.Id);
                await _strategicObjectiveRepository.DeleteAsync(StrategicObjective);
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<GetEditStrategicObjectiveDto> GetStrategicObjectiveEdit  (EntityDto input)
        {
            try
            {
                GetEditStrategicObjectiveDto strategicObjective = new GetEditStrategicObjectiveDto();
                var item = await _strategicObjectiveRepository.GetAllIncluding().IgnoreQueryFilters().Where(x => !x.IsDeleted && x.Id == input.Id).FirstOrDefaultAsync();

                if (item != null)
                {
                    strategicObjective = ObjectMapper.Map<GetEditStrategicObjectiveDto>(item);
                }
                return strategicObjective;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        
    }
}
