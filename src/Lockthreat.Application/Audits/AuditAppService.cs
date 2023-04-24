
using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Lockthreat.Audits.Dto;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessProcesses;
using Lockthreat.BusinessServices;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.OrganizationSetups;
using Lockthreat.Projects;
using Lockthreat.Vendors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.HardwareAssets.Dto;
using Lockthreat.Findings.Dto;
using Lockthreat.Findings;
using Lockthreat.SystemApplications;
using Lockthreat.SystemApplications.Dto;

namespace Lockthreat.Audits
{
   public  class AuditAppService : LockthreatAppServiceBase, IAuditAppService
    {
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;      
        private readonly IRepository<FacilitieDatacenter, long> _facilitiesDataCenterRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<BusinessProcess, long> _businessProcessRepository;
        private readonly IRepository<BusinessService, long> _businessServicesRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly IRepository<Audit,long> _auditRepository;
        private readonly IRepository<AuditAuditor, long> _auditAuditorRepository;
        private readonly IRepository<AuditBusinessProcess, long> _auditBusinessProcessRepository;
        private readonly IRepository<AuditBusinessService, long> _auditBusinessServiceRepository;
        private readonly IRepository<AuditFacilitieDatacenter, long> _auditFacilitieDatacenterRepository;
        private readonly IRepository<AuditTeam, long> _auditTeamRepository;
        private readonly IRepository<AuditVendor, long> _auditVendorRepository;
        private readonly IRepository<AuditAttachment, long> _auditAttachmentRepository;
        private readonly IRepository<AuditFinding, long> _auditFindingRepository;
        private readonly IRepository<Vendor, long> _vendorRepository;
        private readonly IRepository<Project, long> _projectRepository;
        private readonly IRepository<Finding, long> _findingRepository;
        private readonly IRepository<SystemApplication, long> _systemApplicationRepository;
        private readonly IRepository<AuditSystemApplication, long> _auditSystemApplicationRepository;
        public AuditAppService(
        IRepository<AuditSystemApplication, long> auditSystemApplicationRepository,
        IRepository<SystemApplication, long> systemApplicationRepository,
        IRepository<Finding, long> findingRepository,
        IRepository<Vendor, long> vendorRepository,
        ICountriesAppservice countriesAppservice, IRepository<LockThreatOrganization, long> organizationSetupRepository,
        IRepository<FacilitieDatacenter, long> facilitiesDataCenterRepository, IRepository<AuditFinding, long> auditFindingRepository,
        ICodeGeneratorCommonAppservice codegeneratorRepository, IRepository<AuditAttachment, long> auditAttachmentRepository,
        IRepository<Employees.Employee, long> employessRepository, IRepository<AuditVendor, long> auditVendorRepository,
        IRepository<BusinessUnit, long> businessUnitRepository, IRepository<AuditTeam, long> auditTeamRepository,
        IRepository<BusinessProcess, long> businessProcessRepository, IRepository<AuditFacilitieDatacenter, long> auditFacilitieDatacenterRepository,
        IRepository<BusinessService, long> businessServicesRepository, IRepository<AuditBusinessService, long> auditBusinessServiceRepository,
        IRepository<AuditBusinessProcess, long> auditBusinessProcessRepository,
        IRepository<AuditAuditor, long> auditAuditorRepository,
        IRepository<Audit, long> auditRepository, IRepository<Project, long> projectRepository
        )
        {
            _auditSystemApplicationRepository = auditSystemApplicationRepository;
            _systemApplicationRepository = systemApplicationRepository;
            _findingRepository = findingRepository;
            _projectRepository = projectRepository;
            _vendorRepository = vendorRepository;
            _auditRepository = auditRepository;
            _auditBusinessProcessRepository = auditBusinessProcessRepository;
            _auditAuditorRepository = auditAuditorRepository;
            _auditBusinessServiceRepository = auditBusinessServiceRepository;
            _auditFacilitieDatacenterRepository = auditFacilitieDatacenterRepository;
            _auditTeamRepository = auditTeamRepository;
            _auditVendorRepository = auditVendorRepository;
            _auditAttachmentRepository = auditAttachmentRepository;
            _auditFindingRepository = auditFindingRepository;
            _employessRepository = employessRepository;           
            _businessUnitRepository = businessUnitRepository;
            _businessProcessRepository = businessProcessRepository;
            _countriesAppservice = countriesAppservice;
            _organizationSetupRepository = organizationSetupRepository;          
            _facilitiesDataCenterRepository = facilitiesDataCenterRepository;
            _codegeneratorRepository = codegeneratorRepository;            
            _businessServicesRepository = businessServicesRepository;
        }

        public async Task<AuditDto> GetAllAuditInfoDetails(long? auditId)
        {
            try
            {
                var auditInfo = new AuditDto();
                var auditById = new Audit();
                if (auditId > 0)
                {
                    auditById = await _auditRepository.GetAll().FirstOrDefaultAsync(p => p.Id == auditId);
                    auditInfo.SelectedAuditAttachments = ObjectMapper.Map<List<AuditAttachmentDto>>(await _auditAttachmentRepository.GetAll().Where(p => p.AuditId == auditById.Id).ToListAsync());
                    auditInfo.SelectedAuditAuditors = ObjectMapper.Map<List<AuditAuditorDto>>(await _auditAuditorRepository.GetAll().Where(p => p.AuditId == auditById.Id).ToListAsync());
                    auditInfo.SelectedAuditBusinessProcess = ObjectMapper.Map<List<AuditBusinessProcessDto>>(await _auditBusinessProcessRepository.GetAll().Where(p => p.AuditId == auditById.Id).ToListAsync());
                    auditInfo.SelectedAuditBusinessServices = ObjectMapper.Map<List<AuditBusinessServiceDto>>(await _auditBusinessServiceRepository.GetAll().Where(p => p.AuditId == auditById.Id).ToListAsync());
                    auditInfo.SelectedAuditFacilitieDatacenters = ObjectMapper.Map<List<AuditFacilitieDatacenterDto>>(await _auditFacilitieDatacenterRepository.GetAll().Where(p => p.AuditId == auditById.Id).ToListAsync());
                    auditInfo.SelectedAuditFindings = ObjectMapper.Map<List<AuditFindingDto>>(await _auditFindingRepository.GetAll().Where(p => p.AuditId == auditById.Id).ToListAsync());
                    auditInfo.SelectedAuditTeams = ObjectMapper.Map<List<AuditTeamDto>>(await _auditTeamRepository.GetAll().Where(p => p.AuditId == auditById.Id).ToListAsync());
                    auditInfo.SelectedAuditVendors = ObjectMapper.Map<List<AuditVendorDto>>(await _auditVendorRepository.GetAll().Where(p => p.AuditId == auditById.Id).ToListAsync());
                    auditInfo.SelectedAuditSystemApplications = ObjectMapper.Map<List<AuditSystemApplicationDto>>(await _auditSystemApplicationRepository.GetAll().Where(p => p.AuditId == auditById.Id).ToListAsync());
                }
                if (auditById.Id > 0)
                {
                    auditInfo = ObjectMapper.Map<AuditDto>(auditById);
                }

                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                auditInfo.LeadAuditorList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                auditInfo.AuditContactList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                auditInfo.VendorList = ObjectMapper.Map<List<VendorListDto>>(await _vendorRepository.GetAll().ToListAsync());
                auditInfo.ProjectList = ObjectMapper.Map<List<ProjectListDetailsDto>>(await _projectRepository.GetAll().ToListAsync());
                auditInfo.FindingList= ObjectMapper.Map<List<FindingDetailsDto>>(await _findingRepository.GetAll().ToListAsync());
                auditInfo.SystemAplicationList = ObjectMapper.Map<List<SytemApplicationDto>>(await _systemApplicationRepository.GetAll().ToListAsync());
                auditInfo.FacilitiesDatacenterList = ObjectMapper.Map<List<FacilitieDatacenterListDto>>(await _facilitiesDataCenterRepository.GetAll().ToListAsync());
                auditInfo.RelatedBsinessList = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                auditInfo.LockThreatOrganizationList = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                auditInfo.FinacialYearList = await _countriesAppservice.GetAuditYear();
                auditInfo.StatusList = await _countriesAppservice.GetKeyRiskStatus();
                auditInfo.Countries = await _countriesAppservice.GetAll();
                auditInfo.AuditAreaList = await _countriesAppservice.GetAuditArea();
                auditInfo.BusinessProcess = ObjectMapper.Map<List<BusinessProcessDetailDto>>(await _businessProcessRepository.GetAll().ToListAsync());
                auditInfo.BusinessServices = ObjectMapper.Map<List<BusinessServiceSDto>>(await _businessServicesRepository.GetAll().ToListAsync());
                return auditInfo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task CreateOrUpdateAudit(AuditDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.AuditId)) 
                {
                    input.AuditId = _codegeneratorRepository.GetNextId(LockthreatConsts.AUD, "AUD");
                }
                input.TenantId = AbpSession.TenantId;

                if (input.Id > 0)
                {
                    if (input.RemovedAuditAttachments != null)
                    {
                        foreach (var unitId in input.RemovedAuditAttachments)
                        {
                            bool exist = _auditAttachmentRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemovedAuditAttachments(unitId);
                            }
                        }
                    }

                    if (input.RemovedAuditAuditors != null)
                    {
                        foreach (var ext in input.RemovedAuditAuditors)
                        {
                            bool exist = _auditAuditorRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemovedAuditAuditors(ext);
                            }
                        }
                    }

                    if (input.RemovedAuditBusinessProcess != null)
                    {
                        foreach (var ext in input.RemovedAuditBusinessProcess)
                        {
                            bool exist = _auditBusinessProcessRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemovedAuditBusinessProcess(ext);
                            }
                        }
                    }

                    if (input.RemovedAuditBusinessServices != null)
                    {
                        foreach (var unitId in input.RemovedAuditBusinessServices)
                        {
                            bool exist = _auditBusinessServiceRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemovedAuditBusinessServices(unitId);
                            }
                        }
                    }

                    if (input.RemovedAuditFacilitieDatacenters != null)
                    {
                        foreach (var unitId in input.RemovedAuditFacilitieDatacenters)
                        {
                            bool exist = _auditFacilitieDatacenterRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemovedAuditFacilitieDatacenters(unitId);
                            }
                        }
                    }

                    if (input.RemovedAuditFindings != null)
                    {
                        foreach (var unitId in input.RemovedAuditFindings)
                        {
                            bool exist = _auditFindingRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemovedAuditFindings(unitId);
                            }
                        }
                    }

                    if (input.RemovedAuditTeams != null)
                    {
                        foreach (var unitId in input.RemovedAuditTeams)
                        {
                            bool exist = _auditTeamRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemovedAuditTeams(unitId);
                            }
                        }
                    }

                    if (input.RemovedAuditVendors != null)
                    {
                        foreach (var unitId in input.RemovedAuditVendors)
                        {
                            bool exist = _auditVendorRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                await RemovedAuditVendors(unitId);
                            }
                        }
                    }

                }

                await _auditRepository.InsertOrUpdateAsync(ObjectMapper.Map<Audit>(input));

                if (input.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.AUD, "AUD");
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<PagedResultDto<GetAuditListDto>> GetAllAuditList(GetAuditInputDto input)
        {
            try
            {
                var query = _auditRepository.GetAllIncluding().
                    Include(x => x.LeadAuditor).
                    Include(c => c.ProjectName).
                    Include(y => y.LockThreatOrganization).
                    Include(e => e.FinacialYear).
                    Include(g => g.Status).
                    Include(xx => xx.LeadAuditor).
                    Include(e => e.Vendor).
                    Include(g => g.ProjectName)
                   .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);

                var auditCount = await query.CountAsync();

                var auditItems = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var auditListDtos = ObjectMapper.Map<List<GetAuditListDto>>(auditItems);

                return new PagedResultDto<GetAuditListDto>(
                   auditCount,
                   auditListDtos.OrderByDescending(x => x.Id).ToList()
                   );
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveAudit(long hardwareAssetId)
        {
            try
            {
                var audits = await _auditRepository.GetAll().Where(p => p.Id == hardwareAssetId).
                    Include(x => x.SelectedAuditAttachments).
                    Include(x => x.SelectedAuditAuditors).
                    Include(x => x.SelectedAuditBusinessProcess).
                    Include(x => x.SelectedAuditBusinessServices).
                    Include(x => x.SelectedAuditFacilitieDatacenters).
                    Include(x => x.SelectedAuditFindings).
                    Include(x => x.SelectedAuditTeams).
                    Include(x => x.SelectedAuditVendors)
                   .FirstOrDefaultAsync();
                if (audits.SelectedAuditAttachments.Count > 0)
                {
                    foreach (var item in audits.SelectedAuditAttachments)
                    {
                        await RemovedAuditAttachments(item.Id);
                    }
                }

                if (audits.SelectedAuditAuditors.Count > 0)
                {
                    foreach (var item in audits.SelectedAuditAuditors)
                    {
                        await RemovedAuditAuditors(item.Id);
                    }
                }

                if (audits.SelectedAuditBusinessProcess.Count > 0)
                {
                    foreach (var item in audits.SelectedAuditBusinessProcess)
                    {
                        await RemovedAuditBusinessProcess(item.Id);
                    }
                }

                if (audits.SelectedAuditBusinessServices.Count > 0)
                {
                    foreach (var item in audits.SelectedAuditBusinessServices)
                    {
                        await RemovedAuditBusinessServices(item.Id);
                    }
                }

                if (audits.SelectedAuditFacilitieDatacenters.Count > 0)
                {
                    foreach (var item in audits.SelectedAuditFacilitieDatacenters)
                    {
                        await RemovedAuditFacilitieDatacenters(item.Id);
                    }
                }

                if (audits.SelectedAuditFindings.Count > 0)
                {
                    foreach (var item in audits.SelectedAuditFindings)
                    {
                        await RemovedAuditFindings(item.Id);
                    }
                }

                if (audits.SelectedAuditTeams.Count > 0)
                {
                    foreach (var item in audits.SelectedAuditTeams)
                    {
                        await RemovedAuditTeams(item.Id);
                    }
                }

                if (audits.SelectedAuditVendors.Count > 0)
                {
                    foreach (var item in audits.SelectedAuditVendors)
                    {
                        await RemovedAuditVendors(item.Id);
                    }
                }

                await _auditRepository.DeleteAsync(audits);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedAuditAttachments(long id)
        {
            try
            {
                var itservice = await _auditAttachmentRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _auditAttachmentRepository.DeleteAsync(itservice);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedAuditAuditors(long id)
        {
            try
            {
                var employee = await _auditAuditorRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _auditAuditorRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedAuditBusinessProcess(long id)
        {
            try
            {
                var employee = await _auditBusinessProcessRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _auditBusinessProcessRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedAuditBusinessServices(long id)
        {
            try
            {
                var itservice = await _auditBusinessServiceRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _auditBusinessServiceRepository.DeleteAsync(itservice);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedAuditFacilitieDatacenters(long id)
        {
            try
            {
                var employee = await _auditFacilitieDatacenterRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _auditFacilitieDatacenterRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedAuditFindings(long id)
        {
            try
            {
                var employee = await _auditFindingRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _auditFindingRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedAuditTeams(long id)
        {
            try
            {
                var employee = await _auditTeamRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _auditTeamRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedAuditVendors(long id)
        {
            try
            {
                var employee = await _auditVendorRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _auditVendorRepository.DeleteAsync(employee);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
