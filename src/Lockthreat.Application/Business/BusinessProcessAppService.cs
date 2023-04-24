using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.UI;
using Lockthreat.AuthoratativeDocument.Dto;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessProcesses;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.OrganizationSetups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Business
{
    public class BusinessProcessAppService:LockthreatAppServiceBase, IBusinessProcessAppService
    {
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<BusinessProcess, long> _businessProcessRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<AuthoratativeDocuments.AuthoratativeDocument, long> _authdocRepository;
        private readonly IRepository<BusinessProcessAuthoratativeDocument, long> _businessProcessAuthorativeDocumentRepository;
        private readonly IRepository<BusinessProcessService, long> _BusinessProcessServiceRepository;
        private readonly IRepository<BusinessProcessUnit, long> _BusinessProcessUnitRepository;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<BusinessService, long> _businessServicesRepository;
        public BusinessProcessAppService(
            IRepository<BusinessProcess, long> businessProcessRepository,
            IRepository<Employees.Employee, long> employessRepository ,
            IRepository<BusinessProcessAuthoratativeDocument, long> businessProcessAuthorativeDocumentRepository,
            IRepository<BusinessProcessService, long> BusinessProcessServiceRepository,
            IRepository<BusinessProcessUnit, long> BusinessProcessUnitRepository,
            ICodeGeneratorCommonAppservice  codegeneratorRepository,
            IRepository<BusinessUnit, long> businessUnitRepository ,
            IRepository<AuthoratativeDocuments.AuthoratativeDocument, long> authdocRepository,
            ICountriesAppservice countriesAppservice,
            IRepository<BusinessService, long> businessServicesRepository,
            IRepository<LockThreatOrganization, long> organizationSetupRepository
            )
        {
            _employessRepository = employessRepository;
            _businessProcessRepository = businessProcessRepository;
            _businessProcessAuthorativeDocumentRepository = businessProcessAuthorativeDocumentRepository;
            _BusinessProcessServiceRepository = BusinessProcessServiceRepository;
            _BusinessProcessUnitRepository = BusinessProcessUnitRepository;
            _codegeneratorRepository = codegeneratorRepository;
            _businessUnitRepository = businessUnitRepository;
            _organizationSetupRepository = organizationSetupRepository;
            _countriesAppservice = countriesAppservice;
            _authdocRepository = authdocRepository;
            _businessServicesRepository = businessServicesRepository;
        }

        public async Task<BusinessProcessDto> GetAllBusinessprocessInfo(long? businessProcessId)
        {
            try
            {
                var BusinessProcess  = new BusinessProcessDto();
                var BusinessProcessInfoById  = new BusinessProcess();
                if (businessProcessId > 0)
                {
                    BusinessProcessInfoById = await _businessProcessRepository.GetAll().FirstOrDefaultAsync(p => p.Id == businessProcessId);
                }
                if (BusinessProcessInfoById.Id > 0)
                {
                    BusinessProcess = ObjectMapper.Map<BusinessProcessDto>(BusinessProcessInfoById);
                    BusinessProcess.SelectedBusinessProcessUnits = ObjectMapper.Map<List<BusinessProcessUnitDto>>(await _BusinessProcessUnitRepository.GetAll().Where(p => p.BusinessProcessId == BusinessProcessInfoById.Id).ToListAsync());
                    BusinessProcess.SelectedBusinessProcessServices = ObjectMapper.Map<List<BusinessProcessServiceDto>>(await _BusinessProcessServiceRepository.GetAll().Where(p => p.BusinessProcessId == BusinessProcessInfoById.Id).ToListAsync());
                    BusinessProcess.SelectedBusinessProcessAuthorativeDocuments = ObjectMapper.Map<List<BusinessProcessAuthorativeDocumentDto>>(await _businessProcessAuthorativeDocumentRepository.GetAll().Where(p => p.BusinessProcessId == BusinessProcessInfoById.Id).ToListAsync());
                }
                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();                
                BusinessProcess.BusinessUnits = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                BusinessProcess.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                BusinessProcess.ProcessManagers = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                BusinessProcess.ProcessOwners = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                BusinessProcess.Confidentialitys = await _countriesAppservice.GetAllConfidentiality();
                BusinessProcess.Otheres = await _countriesAppservice.GetAllOthers();
                BusinessProcess.Intergritys = await _countriesAppservice.GetAllIntergrity();
                BusinessProcess.ProcessTypes = await _countriesAppservice.GetProcessType();
                BusinessProcess.SlaApplicables = await _countriesAppservice.GetSLA();
                BusinessProcess.ActivityCycles = await _countriesAppservice.GetActivity();
                BusinessProcess.Regulatorys = await _countriesAppservice.GetSLA();
                BusinessProcess.ProcessPrioritys = await _countriesAppservice.GetProcessPriority();
                BusinessProcess.ReviewPeriods = await _countriesAppservice.GetRiviewperiod();
                BusinessProcess.Availibilityes = await _countriesAppservice.GetAvailibility();
                BusinessProcess.Statuses = await _countriesAppservice.GetProcessStatus();
                BusinessProcess.Countries= await _countriesAppservice.GetAll();
                BusinessProcess.BusinessServices= ObjectMapper.Map<List<BusinessServiceSDto>>(await _businessServicesRepository.GetAll().ToListAsync());
                BusinessProcess.AuthoratativeDocuments = ObjectMapper.Map<List<AuthoratativeDocumentsDto>>(await _authdocRepository.GetAll().ToListAsync());
                return BusinessProcess;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<PagedResultDto<BusinessProcessListDto>> GetAllBusinessProcessList(GetBusinessProcessInput input)
        {
            var query = _businessProcessRepository.GetAllIncluding().Include(x => x.LockThreatOrganization).Include(p=>p.Status).Include(x=>x.ProcessOwner).Include(x=>x.ProcessType).Include(x=>x.ProcessPriority)
                        .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);

            var businessProcessCount = await query.CountAsync();

            var businsessProcessItems = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var businessListDtos = ObjectMapper.Map<List<BusinessProcessListDto>>(businsessProcessItems);
            return new PagedResultDto<BusinessProcessListDto>(
               businessProcessCount,
               businessListDtos.ToList()
               );
        }

        public async Task CreateOrUpdateBusinessProcess(BusinessProcessDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.BusinessProcessId))
                {
                    input.BusinessProcessId = _codegeneratorRepository.GetNextId(LockthreatConsts.BusinessProcess, "BPM");
                }
                input.TenantId = AbpSession.TenantId;
                if (input.Id > 0)
                {
                    if (input.RemovedBusinessProcessUnits != null)
                    {
                        foreach (var unitId in input.RemovedBusinessProcessUnits)
                        {
                            bool exist = _BusinessProcessUnitRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemoveBusinessUnit(unitId);
                            }
                        }
                    }

                    if (input.RemovedBusinessProcessServices != null)
                    {
                        foreach (var ext in input.RemovedBusinessProcessServices)
                        {
                            bool exist = _BusinessProcessServiceRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessService(ext);
                            }
                        }
                    }

                    if (input.RemovedBusinessProcessAuthorativeDocuments != null)
                    {
                        foreach (var ext in input.RemovedBusinessProcessAuthorativeDocuments)
                        {
                            bool exist = _businessProcessAuthorativeDocumentRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemoveBusinessAuthorativeDocument(ext);
                            }
                        }
                    }
                }
                await _businessProcessRepository.InsertOrUpdateAsync(ObjectMapper.Map<BusinessProcess>(input));
                if (input.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.BusinessProcess, "BPM");
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task RemoveBusinessUnit (long id)
        {
            try
            {
                var query = await _BusinessProcessUnitRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _BusinessProcessUnitRepository.DeleteAsync(query);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveBusinessService (long id)
        {
            try
            {
                var query  = await _BusinessProcessServiceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _BusinessProcessServiceRepository.DeleteAsync(query);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveBusinessAuthorativeDocument (long id)
        {
            try
            {
                var query = await _businessProcessAuthorativeDocumentRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _businessProcessAuthorativeDocumentRepository.DeleteAsync(query);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task RemoveBusinesProcess (long BusinessProcessId )
        {
            try
            {
                var businessProcess  = await _businessProcessRepository.GetAll().Where(p => p.Id == BusinessProcessId).Include(p => p.SelectedBusinessProcessAuthorativeDocuments).Include(x => x.SelectedBusinessProcessServices).Include(x=>x.SelectedBusinessProcessUnits).FirstOrDefaultAsync();

                if (businessProcess.SelectedBusinessProcessAuthorativeDocuments.Count > 0)
                {
                    foreach (var item in businessProcess.SelectedBusinessProcessAuthorativeDocuments)
                    {
                        await RemoveBusinessAuthorativeDocument(item.Id);
                    }
                }

                if (businessProcess.SelectedBusinessProcessServices.Count > 0)
                {
                    foreach (var item in businessProcess.SelectedBusinessProcessServices)
                    {
                        await RemoveBusinessService(item.Id);
                    }
                }
                if (businessProcess.SelectedBusinessProcessUnits.Count > 0)
                {
                    foreach (var item in businessProcess.SelectedBusinessProcessServices)
                    {
                        await RemoveBusinessUnit(item.Id);
                    }
                }


                await _businessProcessRepository.DeleteAsync(businessProcess);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<GetBusinessProcessForEditDto> GetBusinessProcessForEdit(EntityDto input)
        {
            GetBusinessProcessForEditDto businessProcess = new GetBusinessProcessForEditDto();
            var businessItem = await _businessProcessRepository.GetAllIncluding().IgnoreQueryFilters().Where(x => !x.IsDeleted && x.Id == input.Id).FirstOrDefaultAsync();

            if (businessProcess != null)
            {
                businessProcess = ObjectMapper.Map<GetBusinessProcessForEditDto>(businessItem);
            }
            return businessProcess;
        }

        public string GetNextBusinessProcessId()
        {
            string nextBusinessId = "";
            var Item = _businessProcessRepository.GetAllList().LastOrDefault();
            if (Item != null)
            {
                nextBusinessId = "BPM-" + (Item.Id + 1);
            }
            else
            {
                nextBusinessId = "BPM-1";
            }

            return nextBusinessId;
        }


    }
}
