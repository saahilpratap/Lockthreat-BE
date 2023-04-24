using Abp.Domain.Entities.Auditing;
using Lockthreat.AssetInformations.Dto;
using Lockthreat.AuthoratativeDocument.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.SystemApplications.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Exceptions.Dto
{
  public class GetExceptionInfoDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string ExceptionId { get; set; }
        public DateTime? RequestedDate { get; set; }
        public string BusinessJustification { get; set; }
        public string ExceptionTitle { get; set; }
        public string Comments { get; set; }
        public long? ExpertReviewerId { get; set; }
        public List<BusinessServiceOwner> ExpertReviewers  { get; set; }
        public DateTime? RequestedTillDate { get; set; }
        public DateTime? ReviewDate { get; set; }
        public DateTime? ApprovedTill { get; set; }
        public DateTime? NextReview { get; set; }
        public string RiskDetails { get; set; }
        public int? CritcalityId { get; set; }
        public List<GetDynamicValueDto> Critcalitys  { get; set; }
        public int? ReviewPriorityId { get; set; }
        public List<GetDynamicValueDto> ReviewPrioritys  { get; set; }
        public int? TypeId { get; set; }
        public List<GetDynamicValueDto> Types  { get; set; }
        public int? ExceptionStatusId { get; set; }
        public List<GetDynamicValueDto>  ExceptionStatusList  { get; set; }
        public int? ReviewStatusId { get; set; }
        public List<GetDynamicValueDto> ReviewStatusList  { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; }
        public long? EmployeeId { get; set; }
        public List<BusinessServiceOwner> EmployeesList { get; set; }
        public long? BusinessUnitId { get; set; }
        public List<BusinessUnitPrimaryDto> BusinessUnitOwners { get; set; }     
        public long? AssetInformationId { get; set; }
        public List<AssetInformationListDto> AssetInformations  { get; set; }      
        public List<AuthorativeDocumentDto> AuthoritativeSourceList { get; set; }
        public long? PolicyManagerId { get; set; }
        public List<PolicyManagerDto> PolicyManagers { get; set; }
        public long? SystemApplicationId { get; set; }
        public List<SytemApplicationDto> SystemApplicationList  { get; set; }
        public List<CitationDto> CitationList { get; set; }
        public List<RemediationDto> RemediationList { get; set; }
        public List<ExceptionAuditingControlDto> SelectedExceptionAuditingControls { get; set; }
        public List<ExceptionAuthoratativeDocumentDto> SelectedExceptionAuthoratativeDocuments { get; set; }
        public List<ExceptionBusinessUnitDto> SelectedExceptionBusinessUnits { get; set; }
        public List<ExceptionCitationDto> SelectedExceptionCitations { get; set; }
        public List<ExceptionCitationLibraryDto> SelectedExceptionCitationLibrarys { get; set; }
        public List<ExceptionDocumentDto> SelectedExceptionDocuments { get; set; }
        public List<ExceptionOrganizationDto> SelectedExceptionOrganizations { get; set; }
        public List<ExceptionRemediationDto> SelectedExceptionRemediations { get; set; }
        public List<ExceptionRiskManagementDto> SelectedExceptionRiskManagements  { get; set; }
        public List<long> RemovedExceptionAuditingControl  { get; set; }
        public List<long> RemovedExceptionAuthoratativeDocument  { get; set; }
        public List<long> RemovedExceptionBusinessUnit { get; set; }
        public List<long> RemovedExceptionCitation  { get; set; }
        public List<long> RemovedExceptionCitationLibrary { get; set; }
        public List<long> RemovedExceptionDocument { get; set; }
        public List<long> RemovedExceptionOrganization { get; set; }
        public List<long> RemovedExceptionRemediation  { get; set; }

        public List<long> RemovedExceptionRiskManagement  { get; set; }

    }


    public class AuthorativeDocumentDto
    {
        public long Id { get; set; }
        public string AuthoratativeDocumentTitle { get; set; }
    }

    public class ExceptionRiskManagementDto
    {
        public long Id { get; set; }
        public long? ExceptionId { get; set; }
        public long? RiskManagementId  { get; set; }
        
    }

    public class ExceptionAuditingControlDto
    {
        public long Id { get; set; }
        public long? ExceptionId { get; set; }
        public long? CitationId { get; set; }
    }

    public class ExceptionAuthoratativeDocumentDto
    {
        public long Id { get; set; }
        public long? ExceptionId { get; set; }
        public long? AuthoratativeDocumentId { get; set; }
    }

    public class ExceptionBusinessUnitDto
    {
        public long Id { get; set; }
        public long? ExceptionId { get; set; }
        public long? BusinessUnitId { get; set; }
    }

    public class ExceptionCitationDto
    {
        public long Id { get; set; }
        public long? ExceptionId { get; set; }
        public long? CitationId { get; set; }
    }

    public class ExceptionCitationLibraryDto 
    {
        public long Id { get; set; }
        public long? ExceptionId { get; set; }

        public long? CitationId { get; set; }
    }

    public class ExceptionDocumentDto
    {
        public long Id { get; set; }
        public long? ExceptionId { get; set; }
        public string Document { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }

   public class ExceptionOrganizationDto
    {
        public long Id { get; set; }
        public long? ExceptionId { get; set; }
        public long? LockThreatOrganizationId { get; set; }
    }

    public class ExceptionRemediationDto
    {
        public long Id { get; set; }
        public long? ExceptionId { get; set; }

        public long? RemediationId { get; set; }
    }



   public class PolicyManagerDto
    {
        public long Id { get; set; }
        public string PolicyName  { get; set; }
    }

    public class CitationDto
    {
        public long Id { get; set; }
        public string CitationTitle { get; set; }
    }

    public class RemediationDto
    {
        public long Id { get; set; }
        public string PlanTitle { get; set; } 
    }
}
