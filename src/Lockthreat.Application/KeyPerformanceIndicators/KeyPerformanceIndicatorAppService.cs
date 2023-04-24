using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.KeyPerformanceIndicator;
using Lockthreat.KeyPerformanceIndicator.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.OrganizationSetups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.KeyPerformanceIndicators
{
    public class KeyPerformanceIndicatorAppService:LockthreatAppServiceBase, IKeyPerformanceIndicatorAppService
    {
        private readonly IRepository<KeyPerformanceIndicator, long> _KeyPerformanceIndicatorsRepository;
        private readonly IRepository<KeyPerformanceIndicatorAdministrator,long> _keyperformanceAdministratorRepository;
        private readonly IRepository<KeyPerformanceIndicatorBusinessUnit, long> _keyperFormanceBusinessUnitRepository;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        public KeyPerformanceIndicatorAppService (
            IRepository<KeyPerformanceIndicator, long> KeyPerformanceIndicatorsRepository,
            IRepository<KeyPerformanceIndicatorAdministrator,long> keyperformanceAdministratorRepository,
            IRepository<KeyPerformanceIndicatorBusinessUnit, long> keyperFormanceBusinessUnitRepository,
            IRepository<LockThreatOrganization, long>  organizationSetupRepository,             
            IRepository<BusinessUnit, long> businessUnitRepository,
            ICodeGeneratorCommonAppservice codegeneratorRepositor,
            ICountriesAppservice countriesAppservice,
            IRepository<Employees.Employee, long>  employessRepository
            )
        {
            _KeyPerformanceIndicatorsRepository = KeyPerformanceIndicatorsRepository;
            _keyperformanceAdministratorRepository = keyperformanceAdministratorRepository;
            _keyperFormanceBusinessUnitRepository = keyperFormanceBusinessUnitRepository;
            _organizationSetupRepository = organizationSetupRepository;
            _businessUnitRepository = businessUnitRepository;
            _codegeneratorRepository = codegeneratorRepositor;
            _countriesAppservice = countriesAppservice;
            _employessRepository = employessRepository;
        }


        public async Task<KeyPerformanceDto> GetKeyperformanceInfo (long? KeyPerformanceId )
        {
            try
            {
                var KeyPerformanceinfo  = new KeyPerformanceDto();
                var KeyPerformanceIndicator = new KeyPerformanceIndicator();

                if (KeyPerformanceId > 0)
                {
                    KeyPerformanceIndicator = await _KeyPerformanceIndicatorsRepository.GetAll().FirstOrDefaultAsync(p => p.Id == KeyPerformanceId);
                }

                if (KeyPerformanceIndicator.Id > 0)
                {
                    KeyPerformanceinfo = ObjectMapper.Map<KeyPerformanceDto>(KeyPerformanceIndicator);
                    KeyPerformanceinfo.SelectedBusinessUnits = ObjectMapper.Map<List<KPIBusinessUnitDto>>(await _keyperFormanceBusinessUnitRepository.GetAll().Where(p => p.KeyPerformanceIndicatorId == KeyPerformanceIndicator.Id).ToListAsync());
                    KeyPerformanceinfo.SelectedAdministrators= ObjectMapper.Map<List<KPIAdminisratorDto>>(await _keyperformanceAdministratorRepository.GetAll().Where(p => p.KeyPerformanceIndicatorId == KeyPerformanceIndicator.Id).ToListAsync());
                }

                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                KeyPerformanceinfo.ProgramUser = ObjectMapper.Map<List<ProgramUser>>(employees);
                KeyPerformanceinfo.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());              
                KeyPerformanceinfo.BusinessUnits = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                KeyPerformanceinfo.Statuses = await _countriesAppservice.GetKeyRiskStatus();
                KeyPerformanceinfo.Frequencys= await _countriesAppservice.GetFrequency();
                return KeyPerformanceinfo;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PagedResultDto<KeyPerformanceIndicatorListDto>> GetAllKeyperformanceList (GetKeyPerformanceIndicatorInput input)
        {
            var query = _KeyPerformanceIndicatorsRepository.GetAllIncluding().Include(x=>x.Frequency).Include(y=>y.Status)
                        .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);
            var kpiCount = await query.CountAsync();

            var kpiItems = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var kpiListDtos = ObjectMapper.Map<List<KeyPerformanceIndicatorListDto>>(kpiItems);
            return new PagedResultDto<KeyPerformanceIndicatorListDto>(
               kpiCount,
               kpiListDtos
               );
        }

        public async Task CreateorUpdateKeyPerformance (KeyPerformanceDto  input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.KeyPerformanceIndicatorId))
                {
                    input.KeyPerformanceIndicatorId = _codegeneratorRepository.GetNextId(LockthreatConsts.KPI, "KPI");
                }

                input.TenantId = AbpSession.TenantId;

                if (input.Id > 0)
                {
                    if (input.RemoveAdministrators != null)
                    {
                        foreach (var ext in input.RemoveAdministrators)
                        {
                            bool exist =  _keyperformanceAdministratorRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveAdministrators(ext);
                            }
                        }
                    }

                    if (input.RemoveBusinessUnits != null)
                    {
                        foreach (var ext in input.RemoveBusinessUnits)
                        {
                            bool exist = _keyperFormanceBusinessUnitRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessUnit(ext);
                            }
                        }
                    }
                }

                 await _KeyPerformanceIndicatorsRepository.InsertOrUpdateAsync(ObjectMapper.Map<KeyPerformanceIndicator>(input));

                if(input.Id==0)
                {
                     await  _codegeneratorRepository.CodeCreate(LockthreatConsts.KPI, "KPI");
                }

                

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveAdministrators (long id)
        {
            try
            {
                var keyadminstrator  = await _keyperformanceAdministratorRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _keyperformanceAdministratorRepository.DeleteAsync(keyadminstrator);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveBusinessUnit(long id)
        {           
                try
                {
                    var businessunit = await _keyperFormanceBusinessUnitRepository.FirstOrDefaultAsync(a => a.Id == id);
                    await _keyperFormanceBusinessUnitRepository.DeleteAsync(businessunit);
                }
                catch (Exception ex)
                {
                    throw;
                }            
        }

        public async Task RemoveKeyPerformances  (long KeyPerformanceId )
        {

            try
            {
                var keyperformance  = await _KeyPerformanceIndicatorsRepository.GetAll().Where(p => p.Id == KeyPerformanceId).Include(p => p.SelectedAdministrators).Include(x=>x.SelectedBusinessUnits).FirstOrDefaultAsync();

                if (keyperformance.SelectedBusinessUnits.Count > 0)
                {
                    foreach (var item in keyperformance.SelectedBusinessUnits)
                    {
                        await RemoveBusinessUnit(item.Id);
                    }
                }

                if (keyperformance.SelectedAdministrators.Count > 0)
                {
                    foreach (var item in keyperformance.SelectedAdministrators)
                    {
                        await RemoveAdministrators(item.Id);
                    }
                }
                await _KeyPerformanceIndicatorsRepository.DeleteAsync(keyperformance);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
