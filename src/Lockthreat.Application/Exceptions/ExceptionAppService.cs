using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Lockthreat.AssetInformations;
using Lockthreat.AssetInformations.Dto;
using Lockthreat.AuthoratativeDocument.Dto;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Citations;
using Lockthreat.Common;
using Lockthreat.Countries;
using Lockthreat.Exceptions.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.OrganizationSetups;
using Lockthreat.PolicyManagers;
using Lockthreat.Remediations;
using Lockthreat.SystemApplications;
using Lockthreat.SystemApplications.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using System.Linq.Dynamic.Core;

namespace Lockthreat.Exceptions
{
  public  class ExceptionAppService : LockthreatAppServiceBase, IExceptionAppService
    {
        private readonly IRepository<Exception, long> _exceptionRepository;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<Employees.Employee, long> _employessRepository;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        private readonly ICountriesAppservice _countriesAppservice;
        private readonly IRepository<AuthoratativeDocuments.AuthoratativeDocument, long> _authorativeDocumentRepository;
        private readonly IRepository<AssetInformation, long> _assetInformationRepository;
        private readonly IRepository<PolicyManager, long> _policyManagerRepository;
        private readonly IRepository<Citation, long> _citationRepository;
        private readonly IRepository<Remediation, long> _remediationRepository;
        private readonly IRepository<ExceptionAuditingControl, long> _exceptionAuditingControlRepository;
        private readonly IRepository<ExceptionAuthoratativeDocument, long> _exceptionAuthoratativeDocumentRepository;
        private readonly IRepository<ExceptionBusinessUnit, long> _exceptionBusinessUnitRepository;
        private readonly IRepository<ExceptionCitation, long> _exceptionCitationRepository;
        private readonly IRepository<ExceptionCitationLibrary, long> _exceptionCitationLibraryRepository;
        private readonly IRepository<ExceptionDocument, long> _exceptionDocumentRepository;
        private readonly IRepository<ExceptionOrganization, long> _exceptionOrganizationRepository;
        private readonly IRepository<ExceptionRemediation, long> _exceptionRemediationRepository;
        private readonly IRepository<SystemApplication, long> _systemApplicationRepository;
        private readonly IRepository<ExceptionRiskManagement, long> _exceptionRiskManagementRepository;
      
        public ExceptionAppService(
            IRepository<SystemApplication, long> systemApplicationRepository,
            IRepository<Exception, long> exceptionRepository,
            IRepository<PolicyManager, long> policyManagerRepository,
            IRepository<Citation, long> citationRepository,
            IRepository<AuthoratativeDocuments.AuthoratativeDocument, long> authorativeDocumentRepository,
            IRepository<Remediation, long> remediationRepository,
            IRepository<ExceptionAuditingControl, long> exceptionAuditingControlRepository,
            IRepository<ExceptionAuthoratativeDocument, long> exceptionAuthoratativeDocumentRepository,
            IRepository<ExceptionBusinessUnit, long> exceptionBusinessUnitRepository,
            IRepository<ExceptionCitation, long> exceptionCitationRepository,
            IRepository<ExceptionCitationLibrary, long> exceptionCitationLibraryRepository,
            IRepository<ExceptionDocument, long> exceptionDocumentRepository,
            IRepository<ExceptionOrganization, long> exceptionOrganizationRepository,
           IRepository<ExceptionRemediation, long> exceptionRemediationRepository,
           IRepository<AssetInformation, long> assetInformationRepository,         
           ICountriesAppservice countriesAppservice,
           IRepository<LockThreatOrganization, long> organizationSetupRepository,
           IRepository<Employees.Employee, long> employessRepository,
           IRepository<BusinessUnit, long> businessUnitRepository,
           IRepository<ExceptionRiskManagement, long> exceptionRiskManagementRepository,
           ICodeGeneratorCommonAppservice codegeneratorRepository          
           )
         {
            _exceptionRiskManagementRepository = exceptionRiskManagementRepository;
            _systemApplicationRepository = systemApplicationRepository;
            _exceptionRepository = exceptionRepository;
            _policyManagerRepository = policyManagerRepository;
            _citationRepository = citationRepository;
            _exceptionRemediationRepository = exceptionRemediationRepository;
            _exceptionOrganizationRepository = exceptionOrganizationRepository;
            _exceptionCitationLibraryRepository = exceptionCitationLibraryRepository;
            _exceptionDocumentRepository = exceptionDocumentRepository;
            _exceptionCitationRepository = exceptionCitationRepository;
            _exceptionBusinessUnitRepository = exceptionBusinessUnitRepository;
            _exceptionAuthoratativeDocumentRepository = exceptionAuthoratativeDocumentRepository;
            _exceptionAuditingControlRepository = exceptionAuditingControlRepository;
            _remediationRepository = remediationRepository;
            _authorativeDocumentRepository = authorativeDocumentRepository;
            _countriesAppservice = countriesAppservice;
            _organizationSetupRepository = organizationSetupRepository;
            _codegeneratorRepository = codegeneratorRepository;
            _assetInformationRepository = assetInformationRepository;
            _employessRepository = employessRepository;
            _businessUnitRepository = businessUnitRepository;
        }

        public async Task<PagedResultDto<GetExceptionListDto>> GetAllExceptionList(ExceptionInputDto input)
        {
            try
            {
                var query = _exceptionRepository.GetAllIncluding().
                    Include(x => x.LockThreatOrganization).
                    Include(c => c.ExceptionStatus).
                    Include(y => y.ReviewStatus).                    
                    Include(f => f.BusinessUnit).
                    Include(y => y.ExpertReviewer).
                    Include(f => f.Employee)
                   .WhereIf(input.OrganizationId != null, x => x.LockThreatOrganizationId == input.OrganizationId);

                var exceptionCount = await query.CountAsync();

                var exceptionItems = await query
                    .OrderBy(input.Sorting)
                    .PageBy(input)
                    .ToListAsync();

                var exceptionListDtos = ObjectMapper.Map<List<GetExceptionListDto>>(exceptionItems);

                return new PagedResultDto<GetExceptionListDto>(
                   exceptionCount,
                   exceptionListDtos
                   );
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task<GetExceptionInfoDto> GetAllException (long? exceptionId )
        {
            try
            {
                var exceptions  = new GetExceptionInfoDto();
                var exceptiongById = new Exception();
                if (exceptionId > 0)
                {
                    exceptiongById = await _exceptionRepository.GetAll().FirstOrDefaultAsync(p => p.Id == exceptionId);
                }

                if (exceptiongById.Id > 0)
                {
                    exceptions = ObjectMapper.Map<GetExceptionInfoDto>(exceptiongById);
                    exceptions.SelectedExceptionAuditingControls = ObjectMapper.Map<List<ExceptionAuditingControlDto>>(await _exceptionAuditingControlRepository.GetAll().Where(p => p.ExceptionId == exceptiongById.Id).ToListAsync());
                    exceptions.SelectedExceptionAuthoratativeDocuments = ObjectMapper.Map<List<ExceptionAuthoratativeDocumentDto>>(await _exceptionAuthoratativeDocumentRepository.GetAll().Where(p => p.ExceptionId == exceptiongById.Id).ToListAsync());
                    exceptions.SelectedExceptionBusinessUnits = ObjectMapper.Map<List<ExceptionBusinessUnitDto>>(await _exceptionBusinessUnitRepository.GetAll().Where(p => p.ExceptionId == exceptiongById.Id).ToListAsync());
                    exceptions.SelectedExceptionCitationLibrarys = ObjectMapper.Map<List<ExceptionCitationLibraryDto>>(await _exceptionCitationLibraryRepository.GetAll().Where(p => p.ExceptionId == exceptiongById.Id).ToListAsync());
                    exceptions.SelectedExceptionCitations = ObjectMapper.Map<List<ExceptionCitationDto>>(await _exceptionCitationRepository.GetAll().Where(p => p.ExceptionId == exceptiongById.Id).ToListAsync());
                    exceptions.SelectedExceptionDocuments = ObjectMapper.Map<List<ExceptionDocumentDto>>(await _exceptionDocumentRepository.GetAll().Where(p => p.ExceptionId == exceptiongById.Id).ToListAsync());
                    exceptions.SelectedExceptionOrganizations = ObjectMapper.Map<List<ExceptionOrganizationDto>>(await _exceptionOrganizationRepository.GetAll().Where(p => p.ExceptionId == exceptiongById.Id).ToListAsync());
                    exceptions.SelectedExceptionRemediations = ObjectMapper.Map<List<ExceptionRemediationDto>>(await _exceptionRemediationRepository.GetAll().Where(p => p.ExceptionId == exceptiongById.Id).ToListAsync());
                    exceptions.SelectedExceptionRiskManagements = ObjectMapper.Map<List<ExceptionRiskManagementDto>>(await _exceptionRiskManagementRepository.GetAll().Where(p => p.ExceptionId == exceptiongById.Id).ToListAsync());
                }

                var employees = await _employessRepository.GetAll().Include(e => e.LockThreatOrganization).ToListAsync();
                exceptions.EmployeesList = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);                
                exceptions.BusinessUnitOwners = ObjectMapper.Map<List<BusinessUnitPrimaryDto>>(await _businessUnitRepository.GetAll().ToListAsync());
                exceptions.CompanyLists = ObjectMapper.Map<List<GetOrganizationDto>>(await _organizationSetupRepository.GetAll().ToListAsync());
                exceptions.AssetInformations = ObjectMapper.Map<List<AssetInformationListDto>>(await _assetInformationRepository.GetAll().ToListAsync());
                exceptions.PolicyManagers = ObjectMapper.Map<List<PolicyManagerDto>>(await _policyManagerRepository.GetAll().ToListAsync());
                exceptions.SystemApplicationList = ObjectMapper.Map<List<SytemApplicationDto>>(await _systemApplicationRepository.GetAll().ToListAsync());
                exceptions.CitationList = ObjectMapper.Map<List<CitationDto>>(await _citationRepository.GetAll().ToListAsync());
                exceptions.RemediationList = ObjectMapper.Map<List<RemediationDto>>(await _citationRepository.GetAll().ToListAsync());
                exceptions.ExpertReviewers = ObjectMapper.Map<List<BusinessServiceOwner>>(employees);
                exceptions.ReviewStatusList = await _countriesAppservice.GetExceptionReviewStatus();
                exceptions.ExceptionStatusList = await _countriesAppservice.GetExceptionReviewStatus();
                exceptions.ReviewPrioritys = await _countriesAppservice.GetAllIntergrity();
                exceptions.Critcalitys = await _countriesAppservice.GetAllIntergrity();
                exceptions.Types= await _countriesAppservice.GetExceptionType();
                exceptions.AuthoritativeSourceList= ObjectMapper.Map<List<AuthorativeDocumentDto>>(await _authorativeDocumentRepository.GetAll().ToListAsync());
                return exceptions;
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task CreateOrUpdateException  (GetExceptionInfoDto input)
        {
            try
            {
                if (string.IsNullOrEmpty(input.ExceptionId))
                {
                    input.ExceptionId = _codegeneratorRepository.GetNextId(LockthreatConsts.EXC, "EXC");
                }
                input.TenantId = AbpSession.TenantId;

                if (input.Id > 0)
                {
                    if (input.RemovedExceptionAuditingControl != null)
                    {
                        foreach (var unitId in input.RemovedExceptionAuditingControl)
                        {
                            bool exist = _exceptionAuditingControlRepository.GetAll().Any(t => t.Id == unitId);
                            if (exist)
                            {
                                  await RemovedExceptionAuditingControl(unitId);
                            }
                        }
                    }
                    if (input.RemovedExceptionAuthoratativeDocument != null)
                    {
                        foreach (var ext in input.RemovedExceptionAuthoratativeDocument)
                        {
                            bool exist = _exceptionAuthoratativeDocumentRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemovedExceptionAuthoratativeDocument(ext);
                            }
                        }
                    }
                    if (input.RemovedExceptionBusinessUnit != null)
                    {
                        foreach (var ext in input.RemovedExceptionBusinessUnit)
                        {
                            bool exist = _exceptionBusinessUnitRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                  await RemovedExceptionBusinessUnit(ext);
                            }
                        }
                    }
                    if (input.RemovedExceptionCitation != null)
                    {
                        foreach (var ext in input.RemovedExceptionCitation)
                        {
                            bool exist = _exceptionCitationRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                  await RemovedExceptionCitation(ext);
                            }
                        }
                    }
                    if (input.RemovedExceptionCitationLibrary != null)
                    {
                        foreach (var ext in input.RemovedExceptionCitationLibrary)
                        {
                            bool exist = _exceptionCitationLibraryRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                  await RemovedExceptionCitationLibrary(ext);
                            }
                        }
                    }
                    if (input.RemovedExceptionDocument != null)
                    {
                        foreach (var ext in input.RemovedExceptionDocument)
                        {
                            bool exist = _exceptionDocumentRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                  await RemovedExceptionDocument(ext);
                            }
                        }
                    }
                    if (input.RemovedExceptionOrganization != null)
                    {
                        foreach (var ext in input.RemovedExceptionOrganization)
                        {
                            bool exist = _exceptionOrganizationRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                  await RemovedExceptionOrganization(ext);
                            }
                        }
                    }
                    if (input.RemovedExceptionRemediation != null)
                    {
                        foreach (var ext in input.RemovedExceptionRemediation)
                        {
                            bool exist = _exceptionRemediationRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                  await RemovedExceptionRemediation(ext);
                            }
                        }
                    }
                    if (input.RemovedExceptionRiskManagement != null)
                    {
                        foreach (var ext in input.RemovedExceptionRiskManagement)
                        {
                            bool exist = _exceptionRiskManagementRepository.GetAll().Any(t => t.Id == ext);
                            if (exist)
                            {
                                await RemovedExceptionRiskManagement (ext);
                            }
                        }
                    }
                }

                await _exceptionRepository.InsertOrUpdateAsync(ObjectMapper.Map<Exception>(input));

                if (input.Id == 0)
                {
                    await _codegeneratorRepository.CodeCreate(LockthreatConsts.EXC, "EXC");
                }

            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedExceptionAuditingControl (long id)
        {
            try
            {
                var exceptionaudit = await _exceptionAuditingControlRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _exceptionAuditingControlRepository.DeleteAsync(exceptionaudit);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedExceptionAuthoratativeDocument(long id)
        {
            try
            {
                var exceptionauth = await _exceptionAuthoratativeDocumentRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _exceptionAuthoratativeDocumentRepository.DeleteAsync(exceptionauth);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedExceptionCitation(long id)
        {
            try
            {
                var exceptionCitations = await _exceptionCitationRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _exceptionCitationRepository.DeleteAsync(exceptionCitations);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedExceptionCitationLibrary(long id)
        {
            try
            {
                var exceptioncitation  = await _exceptionCitationLibraryRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _exceptionCitationLibraryRepository.DeleteAsync(exceptioncitation);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedExceptionBusinessUnit(long id)
        {
            try
            {
                var exceptionunit = await _exceptionBusinessUnitRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _exceptionBusinessUnitRepository.DeleteAsync(exceptionunit);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedExceptionDocument(long id)
        {
            try
            {
                var exceptionDocument  = await _exceptionDocumentRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _exceptionDocumentRepository.DeleteAsync(exceptionDocument);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedExceptionOrganization(long id)
        {
            try
            {
                var exceptionOrg = await _exceptionOrganizationRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _exceptionOrganizationRepository.DeleteAsync(exceptionOrg);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task RemovedExceptionRemediation(long id)
        {
            try
            {
                var exceptionremeiation  = await _exceptionRemediationRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _exceptionRemediationRepository.DeleteAsync(exceptionremeiation);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

        public async Task RemovedExceptionRiskManagement (long id)
        {
            try
            {
                var exceptionrisk  = await _exceptionRiskManagementRepository.FirstOrDefaultAsync(e => e.Id == id);
                await _exceptionRiskManagementRepository.DeleteAsync(exceptionrisk);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }
        public async Task RemoveException(long exceptionId )
        {
            try
            {
                var exception  = await _exceptionRepository.GetAll().Where(p => p.Id == exceptionId)
                    .Include(p => p.SelectedExceptionAuditingControls)
                    .Include(x => x.SelectedExceptionAuthoratativeDocuments)
                    .Include(x => x.SelectedExceptionBusinessUnits)
                    .Include(p => p.SelectedExceptionCitationLibrarys)
                    .Include(x => x.SelectedExceptionCitations)
                    .Include(x => x.SelectedExceptionDocuments)
                     .Include(x => x.SelectedExceptionOrganizations)
                      .Include(x => x.SelectedExceptionRiskManagements)
                    .Include(x => x.SelectedExceptionRemediations)
                    .FirstOrDefaultAsync();

                if (exception.SelectedExceptionAuditingControls.Count > 0)
                {
                    foreach (var item in exception.SelectedExceptionAuditingControls)
                    {
                        await RemovedExceptionAuditingControl(item.Id);
                    }
                }

                if (exception.SelectedExceptionAuthoratativeDocuments.Count > 0)
                {
                    foreach (var item in exception.SelectedExceptionAuthoratativeDocuments)
                    {
                        await RemovedExceptionAuthoratativeDocument(item.Id);
                    }
                }

                if (exception.SelectedExceptionBusinessUnits.Count > 0)
                {
                    foreach (var item in exception.SelectedExceptionBusinessUnits)
                    {
                        await RemovedExceptionBusinessUnit(item.Id);
                    }
                }


                if (exception.SelectedExceptionCitationLibrarys.Count > 0)
                {
                    foreach (var item in exception.SelectedExceptionCitationLibrarys)
                    {
                        await RemovedExceptionCitationLibrary(item.Id);
                    }
                }

                if (exception.SelectedExceptionCitations.Count > 0)
                {
                    foreach (var item in exception.SelectedExceptionCitations)
                    {
                        await RemovedExceptionCitation(item.Id);
                    }
                }

                if (exception.SelectedExceptionDocuments.Count > 0)
                {
                    foreach (var item in exception.SelectedExceptionDocuments)
                    {
                        await RemovedExceptionDocument(item.Id);
                    }
                }
                if (exception.SelectedExceptionOrganizations.Count > 0)
                {
                    foreach (var item in exception.SelectedExceptionOrganizations)
                    {
                        await RemovedExceptionOrganization(item.Id);
                    }
                }

                if (exception.SelectedExceptionRemediations.Count > 0)
                {
                    foreach (var item in exception.SelectedExceptionRemediations)
                    {
                        await RemovedExceptionRemediation(item.Id);
                    }
                }
                if (exception.SelectedExceptionRiskManagements.Count > 0)
                {
                    foreach (var item in exception.SelectedExceptionRiskManagements)
                    {
                        await RemovedExceptionRiskManagement(item.Id);
                    }
                }
                await _exceptionRepository.DeleteAsync(exception);
            }
            catch (System.Exception ex)
            {
                throw;
            }
        }

    }
}
