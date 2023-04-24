using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Lockthreat.BusinessEntities;
using Lockthreat.ITServices;
using Lockthreat.ITservices.Dto;
using Lockthreat.BusinessServices;
using Lockthreat.Countries;
using Lockthreat.Common;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.OrganizationSetups;
using Lockthreat.BusinessProcesses.Dto;
namespace Lockthreat.ITservices
{
    public class ITServiceAppService : LockthreatAppServiceBase, IITServiceAppService
    {
        private readonly IRepository<ITService, long> _itservicesRepository;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<BusinessService, long> _businessServicesRepository;
        private readonly IRepository<ITServiceBusinessService, long> _ItServiceBusinessServiceRepository ;
        private readonly IRepository<ITServiceBusinessUnit, long> _ItServiceBusinessUnitRepository ;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;

        public ITServiceAppService(
           IRepository<ITService, long> itservicesRepository,
           IRepository<BusinessUnit, long> businessUnitRepository,
           IRepository<BusinessService, long> businessServicesRepository,
           IRepository<ITServiceBusinessService, long> ItServiceBusinessServiceRepository,
           IRepository<ITServiceBusinessUnit, long> ItServiceBusinessUnitRepository,
           ICountriesAppservice countriesAppservice,
           ICodeGeneratorCommonAppservice codegeneratorRepository,
           IRepository<Employees.Employee, long> employessRepository,
           IRepository<LockThreatOrganization, long> organizationSetupRepository 
           )
        {
            _itservicesRepository = itservicesRepository;
            _businessUnitRepository = businessUnitRepository;
            _businessServicesRepository = businessServicesRepository;
            _ItServiceBusinessServiceRepository = ItServiceBusinessServiceRepository;
            _ItServiceBusinessUnitRepository = ItServiceBusinessUnitRepository;
            _countriesAppservice = countriesAppservice;
            _codegeneratorRepository = codegeneratorRepository;
            _employessRepository = employessRepository;
            _organizationSetupRepository = organizationSetupRepository;
        }

        public async Task<List<GetITserviceForBusinessServiceDto>> GetAllITserviceUnderOraganization(long OrgId)
        {
            var getITservice = new List<GetITserviceForBusinessServiceDto>();
            try
            {
                var getITservices = await _itservicesRepository.GetAll().Where(x => x.LockThreatOrganizationId == OrgId).ToListAsync();

                if (getITservices != null)
                {
                    getITservice = ObjectMapper.Map<List<GetITserviceForBusinessServiceDto>>(getITservices);
                }
                return getITservice;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<ITserviceDto> GetITserviceInfo (long? ITserviceId )
        {
            try
            {
                ITserviceDto ITservices   = new ITserviceDto();
                ITService ITServiceById  = new ITService();
                if (ITserviceId > 0)
                {
                    ITServiceById = await _itservicesRepository.GetAll().FirstOrDefaultAsync(p => p.Id == ITserviceId);
                }
                if (ITServiceById.Id > 0)
                {
                    ITservices = ObjectMapper.Map<ITserviceDto>(ITServiceById);
                    ITservices.SelectedITserviceBusinessServices = ObjectMapper.Map<List<ITserviceBusinessServiceDto>>(await _ItServiceBusinessServiceRepository.GetAll().Where(p => p.ITServiceId == ITServiceById.Id).ToListAsync());
                    ITservices.SelectedITserviceBusinessUnit = ObjectMapper.Map<List<ITserviceBusinessUnitDto>>(await _ItServiceBusinessUnitRepository.GetAll().Where(p => p.ITServiceId == ITServiceById.Id).ToListAsync());                   
                }

                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                ITservices.BusinessUnits = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                ITservices.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                ITservices.ITServiceManagers = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                ITservices.ITServiceOwners = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                ITservices.Confidentialitys = await _countriesAppservice.GetAllConfidentiality();
                ITservices.Otheres = await _countriesAppservice.GetAllOthers();
                ITservices.Integritys = await _countriesAppservice.GetAllIntergrity();
                ITservices.Availibilitys = await _countriesAppservice.GetAvailibility();                    
                ITservices.ServiceTypes = await _countriesAppservice.GetProcessType();
                ITservices.ServiceClassifications = await _countriesAppservice.GetAllConfidentiality();
                ITservices.RegulatoryMandates = await _countriesAppservice.GetSLA();
                ITservices.Countries = await _countriesAppservice.GetAll();                
                ITservices.BusinessServices = ObjectMapper.Map<List<BusinessServiceSDto>>(await _businessServicesRepository.GetAll().ToListAsync());               
                return ITservices;


            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<PagedResultDto<GetITserviceListDto>> GetAllITServiceList(GetITserviceInput input)
        {
            var query = _itservicesRepository.GetAllIncluding().Include(x => x.LockThreatOrganization).Include(p => p.ServiceType).Include(x => x.ServiceClassification).Include(x => x.ITServiceOwner).Include(x => x.BusinessUnit).Include(x=>x.Confidentiality).Include(x=>x.Integrity)
                        .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);

            var businessItserviceCount   = await query.CountAsync();

            var businessItserviceItems  = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var businessListDtos = ObjectMapper.Map<List<GetITserviceListDto>>(businessItserviceItems);
            return new PagedResultDto<GetITserviceListDto>(
               businessItserviceCount,
               businessListDtos.ToList()
               );
        }
        public async Task CreateOrUpdateITservice (ITserviceDto  input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.ITServicesId))
                {
                    input.ITServicesId = _codegeneratorRepository.GetNextId(LockthreatConsts.ITService, "ITS");
                }
                input.TenantId = AbpSession.TenantId;
                if (input.Id > 0)
                {
                    if (input.RemoveITserviceBusinessUnit != null)
                    {
                        foreach (var unitId in input.RemoveITserviceBusinessUnit)
                        {
                            bool exist = _ItServiceBusinessUnitRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemoveBusinessUnit(unitId);
                            }
                        }
                    }

                    if (input.RemoveITserviceBusinessServices != null)
                    {
                        foreach (var ext in input.RemoveITserviceBusinessServices)
                        {
                            bool exist = _ItServiceBusinessServiceRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessService(ext);
                            }
                        }
                    }                   
                }

                await _itservicesRepository.InsertOrUpdateAsync(ObjectMapper.Map<ITService>(input));
                if (input.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.ITService, "ITS");
                }
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
                var query = await _ItServiceBusinessUnitRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _ItServiceBusinessUnitRepository.DeleteAsync(query);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveBusinessService(long id)
        {
            try
            {
                var query = await _ItServiceBusinessServiceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _ItServiceBusinessServiceRepository.DeleteAsync(query);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveITService (long ITserviceId )
        {
            try
            {
                var Itservice  = await _itservicesRepository.GetAll().Where(p => p.Id == ITserviceId).Include(p => p.SelectedITserviceBusinessServices).Include(x => x.SelectedITserviceBusinessUnit).FirstOrDefaultAsync();

                if (Itservice.SelectedITserviceBusinessServices.Count > 0)
                {
                    foreach (var item in Itservice.SelectedITserviceBusinessServices)
                    {
                        await RemoveBusinessService(item.Id);
                    }
                }

                if (Itservice.SelectedITserviceBusinessUnit.Count > 0)
                {
                    foreach (var item in Itservice.SelectedITserviceBusinessUnit)
                    {
                        await RemoveBusinessUnit(item.Id);
                    }
                }               
                await _itservicesRepository.DeleteAsync(Itservice);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
