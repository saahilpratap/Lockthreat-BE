using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessProcesses;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.FacilitieDatacenters.Dto;
using Lockthreat.FacilitiesDatacenters;
using Lockthreat.ITServices;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.OrganizationSetups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;


namespace Lockthreat.FacilitieDatacenters
{
  public  class FacilitieDatacenterAppService : LockthreatAppServiceBase,IFacilitieDatacenterAppService
    {
        private readonly IRepository<ITService, long> _itservicesRepository;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<BusinessProcess, long> _businessProcessRepository;
        private readonly IRepository<BusinessService, long> _businessServicesRepository;
        private readonly IRepository<FacilitieDatacenter, long> _facilitieDatacenterRepository;
        private readonly IRepository<FacilitieDatacenterITService, long> _facilitieDatacenterITServiceRepository;
        private readonly IRepository<FacilitieDatacenterProcess, long> _facilitieDatacenterProcessRepository;
        private readonly IRepository<FacilitieDatacenterService, long> _facilitieDatacenterServiceRepository ;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        public FacilitieDatacenterAppService (
            IRepository<BusinessProcess, long> businessProcessRepository,
            IRepository<Employees.Employee, long> employessRepository,           
            ICodeGeneratorCommonAppservice codegeneratorRepository,
            IRepository<BusinessUnit, long> businessUnitRepository,          
            ICountriesAppservice countriesAppservice,
            IRepository<BusinessService, long> businessServicesRepository,
            IRepository<LockThreatOrganization, long> organizationSetupRepository,
            IRepository<FacilitieDatacenterService, long> facilitieDatacenterServiceRepository,
            IRepository<FacilitieDatacenterProcess, long> facilitieDatacenterProcessRepository,
            IRepository<FacilitieDatacenterITService, long> facilitieDatacenterITServiceRepository,
             IRepository<ITService, long> itservicesRepository,
            IRepository<FacilitieDatacenter, long> facilitieDatacenterRepository
            )
        {
            _employessRepository = employessRepository;
            _businessProcessRepository = businessProcessRepository;            
            _codegeneratorRepository = codegeneratorRepository;
            _businessUnitRepository = businessUnitRepository;
            _organizationSetupRepository = organizationSetupRepository;
            _countriesAppservice = countriesAppservice;           
            _businessServicesRepository = businessServicesRepository;
            _facilitieDatacenterServiceRepository = facilitieDatacenterServiceRepository;
            _facilitieDatacenterProcessRepository = facilitieDatacenterProcessRepository;
            _facilitieDatacenterITServiceRepository = facilitieDatacenterITServiceRepository;
            _facilitieDatacenterRepository = facilitieDatacenterRepository;
            _itservicesRepository = itservicesRepository;
        }

        public async Task<FacilitieDatacenterDto> GetAllFacilitieDatacenterInfo (long? facilitieDatacenterId )
        {
            try
            {
                var facilitieDatacenter = new FacilitieDatacenterDto();
                var facilitieDatacenterById = new FacilitieDatacenter();
                if (facilitieDatacenterId > 0)
                {
                    facilitieDatacenterById = await _facilitieDatacenterRepository.GetAll().FirstOrDefaultAsync(p => p.Id == facilitieDatacenterId);
                }
                if (facilitieDatacenterById.Id > 0)
                {
                    facilitieDatacenter = ObjectMapper.Map<FacilitieDatacenterDto>(facilitieDatacenterById);
                    facilitieDatacenter.SelectedFacilitieDatacenterITServices = ObjectMapper.Map<List<FacilitieDatacenterITServiceDto>>(await _facilitieDatacenterITServiceRepository.GetAll().Where(p => p.FacilitieDatacenterId == facilitieDatacenterById.Id).ToListAsync());
                    facilitieDatacenter.SelectedFacilitieDatacenterProcess = ObjectMapper.Map<List<FacilitieDatacenterProcessDto>>(await _facilitieDatacenterProcessRepository.GetAll().Where(p => p.FacilitieDatacenterId == facilitieDatacenterById.Id).ToListAsync());
                    facilitieDatacenter.SelectedFacilitieDatacenterServices = ObjectMapper.Map<List<FacilitieDatacenterServiceDto>>(await _facilitieDatacenterServiceRepository.GetAll().Where(p => p.FacilitieDatacenterId == facilitieDatacenterById.Id).ToListAsync());
                }
                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                facilitieDatacenter.EmployeesList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                facilitieDatacenter.BusinessUnitGaurdians = ObjectMapper.Map<List<BusinessUnitGaurdianDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                facilitieDatacenter.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                facilitieDatacenter.BusinessUnitOwners = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                facilitieDatacenter.ITserviceLists = ObjectMapper.Map<List<ITserviceListDto>>(await _itservicesRepository.GetAll().ToListAsync());
                facilitieDatacenter.Confidentialitys = await _countriesAppservice.GetAllConfidentiality();
                facilitieDatacenter.Otheres = await _countriesAppservice.GetAllOthers();
                facilitieDatacenter.Integritys = await _countriesAppservice.GetAllIntergrity();
                facilitieDatacenter.FacilityTypes = await _countriesAppservice.GetFacilityType();
                facilitieDatacenter.Availibilitys = await _countriesAppservice.GetAvailibility();
                facilitieDatacenter.Countries = await _countriesAppservice.GetAll();
                facilitieDatacenter.BusinessProcess= ObjectMapper.Map<List<BusinessProcessDetailDto>>(await _businessProcessRepository.GetAll().ToListAsync());
                facilitieDatacenter.BusinessServices = ObjectMapper.Map<List<BusinessServiceSDto>>(await _businessServicesRepository.GetAll().ToListAsync());
                return facilitieDatacenter;

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreateOrUpdateFacilitieDatacenter (FacilitieDatacenterDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.FacilityId))
                {
                    input.FacilityId = _codegeneratorRepository.GetNextId(LockthreatConsts.FID, "FID");
                }
                input.TenantId = AbpSession.TenantId;

                if (input.Id > 0)
                {
                    if (input.RemovedFacilitieDatacenterITService != null)
                    {
                        foreach (var unitId in input.RemovedFacilitieDatacenterITService)
                        {
                            bool exist = _facilitieDatacenterITServiceRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemoveItService(unitId);
                            }
                        }
                    }

                    if (input.RemovedFacilitieDatacenterProcess != null)
                    {
                        foreach (var ext in input.RemovedFacilitieDatacenterProcess)
                        {
                            bool exist = _facilitieDatacenterProcessRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessProcess(ext);
                            }
                        }
                    }

                    if (input.RemovedFacilitieDatacenterService != null)
                    {
                        foreach (var ext in input.RemovedFacilitieDatacenterService)
                        {
                            bool exist = _facilitieDatacenterServiceRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessService(ext);
                            }
                        }
                    }

                }

                await _facilitieDatacenterRepository.InsertOrUpdateAsync(ObjectMapper.Map<FacilitieDatacenter>(input));

                if (input.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.FID, "FID");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PagedResultDto<GetFacilitiesDatacenterListDto>> GetAllFacilitiesDatacenterList (GetFacilitiesDatacenterInput  input)
        {
            try
            {
                var query = _facilitieDatacenterRepository.GetAllIncluding().
                    Include(x => x.Confidentiality).
                    Include(c => c.Integrity).
                    Include(y => y.LockThreatOrganization).                 
                    Include(e => e.Others).
                    Include(f => f.BusinessUnitOwner).
                    Include(g => g.FacilityType).
                    Include(xx => xx.Availibility)
                   .Include(yy => yy.BusinessUnitGaurdian)                 
                   .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);

                var facilitiesDatacenterCount = await query.CountAsync();

                var facilitiesDatacenterItems  = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var facilitiesDatacenterListDtos  = ObjectMapper.Map<List<GetFacilitiesDatacenterListDto>>(facilitiesDatacenterItems);

                return new PagedResultDto<GetFacilitiesDatacenterListDto>(
                   facilitiesDatacenterCount,
                   facilitiesDatacenterListDtos
                   );
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveItService(long id)
        {
            try
            {
                var itservice = await _facilitieDatacenterITServiceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _facilitieDatacenterITServiceRepository.DeleteAsync(itservice);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveBusinessProcess(long id)
        {
            try
            {
                var employee = await _facilitieDatacenterProcessRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _facilitieDatacenterProcessRepository.DeleteAsync(employee);
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
                var employee = await _facilitieDatacenterServiceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _facilitieDatacenterServiceRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveFacilitieDatacenter (long facilitieDatacenterId )
        {
            try
            {
                var facilitieDatacenter = await _facilitieDatacenterRepository.GetAll().Where(p => p.Id == facilitieDatacenterId).Include(p => p.SelectedFacilitieDatacenterITServices).Include(x => x.SelectedFacilitieDatacenterProcess).Include(x=>x.SelectedFacilitieDatacenterServices).FirstOrDefaultAsync();

                if (facilitieDatacenter.SelectedFacilitieDatacenterITServices.Count > 0)
                {
                    foreach (var item in facilitieDatacenter.SelectedFacilitieDatacenterITServices)
                    {
                        await RemoveItService(item.Id);
                    }
                }

                if (facilitieDatacenter.SelectedFacilitieDatacenterProcess.Count > 0)
                {
                    foreach (var item in facilitieDatacenter.SelectedFacilitieDatacenterProcess)
                    {
                        await RemoveBusinessProcess (item.Id);
                    }
                }

                if (facilitieDatacenter.SelectedFacilitieDatacenterServices.Count > 0)
                {
                    foreach (var item in facilitieDatacenter.SelectedFacilitieDatacenterServices)
                    {
                        await RemoveBusinessService(item.Id);
                    }
                }
                await _facilitieDatacenterRepository.DeleteAsync(facilitieDatacenter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
