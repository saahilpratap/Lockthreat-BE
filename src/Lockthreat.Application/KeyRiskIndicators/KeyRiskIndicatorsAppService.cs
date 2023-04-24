using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using AutoMapper;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.KeyRiskIndicator;
using Lockthreat.KeyRiskIndicator.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.OrganizationSetups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.KeyRiskIndicators
{
    public class KeyRiskIndicatorsAppService:LockthreatAppServiceBase, IKeyRiskIndicatorsAppService
    {
        private readonly IRepository<KeyRiskIndicator, long> _KeyRiskIndicatorsRepository;
        public readonly IRepository<KeyRiskIndicatorBusinessUnit, long> _keyRiskIndicatorsUnitRepository;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        public KeyRiskIndicatorsAppService(
             ICountriesAppservice countriesAppservice,
            IRepository<KeyRiskIndicator, long> KeyRiskIndicatorsRepository, 
            IRepository<KeyRiskIndicatorBusinessUnit, long> keyRiskIndicatorsUnitRepository,
            IRepository<LockThreatOrganization, long> organizationSetupRepository,
            IRepository<BusinessUnit, long> businessUnitRepository,
            ICodeGeneratorCommonAppservice codegeneratorRepository            
            )
        {
            _KeyRiskIndicatorsRepository = KeyRiskIndicatorsRepository;
            _keyRiskIndicatorsUnitRepository = keyRiskIndicatorsUnitRepository;
            _organizationSetupRepository = organizationSetupRepository;
            _businessUnitRepository = businessUnitRepository;
            _countriesAppservice = countriesAppservice;
            _codegeneratorRepository = codegeneratorRepository;
        }

        public async Task<KeyRiskIndicatorDto> GetKeyRiskIndicatorInfo(long? KeyRiskIndicatorsId)
        {
            try
            {
                var KeyRiskIndicatorinfo = new KeyRiskIndicatorDto();
                var KeyRiskIndicator = new KeyRiskIndicator();

                if (KeyRiskIndicatorsId > 0)
                {
                    KeyRiskIndicator = await _KeyRiskIndicatorsRepository.GetAll().FirstOrDefaultAsync(p => p.Id == KeyRiskIndicatorsId);
                }

                if (KeyRiskIndicator.Id > 0)
                {
                    KeyRiskIndicatorinfo = ObjectMapper.Map<KeyRiskIndicatorDto>(KeyRiskIndicator);
                    KeyRiskIndicatorinfo.SelectdBusinessUnits = ObjectMapper.Map<List<BusinessUnitKeyRiskDto>>(await _keyRiskIndicatorsUnitRepository.GetAll().Where(p => p.KeyRiskIndicatorId == KeyRiskIndicator.Id).ToListAsync());
                }

                var organization = await _organizationSetupRepository.GetAll().ToListAsync();
                KeyRiskIndicatorinfo.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(organization);
                KeyRiskIndicatorinfo.BusinessUnits = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                KeyRiskIndicatorinfo.Statuses = await _countriesAppservice.GetKeyRiskStatus();
                return KeyRiskIndicatorinfo;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PagedResultDto<KeyRiskIndicatorListDto>> GetKeyRiskIndicatorList  (GetKeyRiskIndicatorInput input)
        {
            try
            {
                var query = _KeyRiskIndicatorsRepository.GetAllIncluding().Include(x => x.Status)              
                             .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);


                var keyriskindicator  = await query.CountAsync();

                var keyriskindicators  = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var keyrisk  = ObjectMapper.Map<List<KeyRiskIndicatorListDto>>(keyriskindicators);

                return new PagedResultDto<KeyRiskIndicatorListDto>(
                   keyriskindicator,
                   keyrisk.ToList()
                   );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public async Task CreateorUpdateKeyRiskIndicator (KeyRiskIndicatorDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.KeyRiskIndicatorsId))
                {
                    input.KeyRiskIndicatorsId = _codegeneratorRepository.GetNextId(LockthreatConsts.KRI, "KRI");
                }

                input.TenantId = AbpSession.TenantId;
                
                if (input.Id > 0)
                {
                    var keyriskindicators  = await _KeyRiskIndicatorsRepository.
                        GetAll().
                        Include(x => x.SelectdBusinessUnits).FirstOrDefaultAsync(x => x.Id == input.Id);
                     await _keyRiskIndicatorsUnitRepository.HardDeleteAsync(r => r.KeyRiskIndicatorId == input.Id);
                    ObjectMapper.Map(input, keyriskindicators);
                    //    if (input.RemoveBusinessUnit != null)
                    //    {
                    //        foreach (var ext in input.RemoveBusinessUnit)
                    //        {
                    //            bool exist = _keyRiskIndicatorsUnitRepository.GetAll().Any(t => t.Id == ext);
                    //            if (exist)
                    //            {
                    //                await RemoveBusinessunit(ext);
                    //            }
                    //        }
                    //    }
                }
               

                if (input.Id == 0)
                {
                    await _KeyRiskIndicatorsRepository.InsertAsync(ObjectMapper.Map<KeyRiskIndicator>(input));
                    await  _codegeneratorRepository.CodeCreate(LockthreatConsts.KRI, "KRI");
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveBusinessunit (long id)
        {
            try
            {
                var businessunit  = await _keyRiskIndicatorsUnitRepository.FirstOrDefaultAsync(a => a.Id == id);
                await _keyRiskIndicatorsUnitRepository.DeleteAsync(businessunit);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task RemoveKeyRiskIndicator(long keyRiskIndicatorId )
        {

            try
            {
                var program = await _KeyRiskIndicatorsRepository.GetAll().Where(p => p.Id == keyRiskIndicatorId).Include(p => p.SelectdBusinessUnits).FirstOrDefaultAsync();

                if (program.SelectdBusinessUnits.Count > 0)
                {
                    foreach (var item in program.SelectdBusinessUnits)
                    {
                        await RemoveBusinessunit(item.Id);
                    }
                }               
                await _KeyRiskIndicatorsRepository.DeleteAsync(program);
            }
            catch (Exception ex)
            {
                throw;
            }
        }    

    }
     
}
