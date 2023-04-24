using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.AssetInformations;
using Lockthreat.BusinessEntities;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using Lockthreat.PolicyManagers;
using Lockthreat.SystemApplications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Exceptions
{
  public class Exception : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string ExceptionId { get; set; }
        public DateTime? RequestedDate { get; set; }

        public DateTime? RequestedTillDate  { get; set; }
        public string  BusinessJustification { get; set; }
        public string ExceptionTitle { get; set; }
        public string Comments { get; set; }           
        public long? ExpertReviewerId  { get; set; }
        public Employee ExpertReviewer  { get; set; }

        public DateTime? ReviewDate { get; set; }

        public DateTime? ApprovedTill { get; set; }

        public DateTime? NextReview { get; set; }

        public string RiskDetails { get; set; }

        public int? CritcalityId { get; set; }
        public DynamicParameterValue Critcality { get; set; }

        public int? ReviewPriorityId  { get; set; }
        public DynamicParameterValue ReviewPriority { get; set; }

        public int? TypeId  { get; set; }
        public DynamicParameterValue Type  { get; set; }

        public int? ExceptionStatusId  { get; set; }
        public DynamicParameterValue ExceptionStatus  { get; set; }

        public int? ReviewStatusId  { get; set; }
        public DynamicParameterValue ReviewStatus  { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee { get; set; }

        public long? BusinessUnitId  { get; set; }
        public BusinessUnit BusinessUnit { get; set; }

        public long? AssetInformationId  { get; set; }
        public AssetInformation AssetInformation { get; set; }

        public long? PolicyManagerId  { get; set; }
        public PolicyManager PolicyManager { get; set; }

        public long? SystemApplicationId  { get; set; }
        public SystemApplication SystemApplication { get; set; }

        public ICollection<ExceptionAuditingControl> SelectedExceptionAuditingControls  { get; set; }
        public ICollection<ExceptionAuthoratativeDocument> SelectedExceptionAuthoratativeDocuments  { get; set; }
        public ICollection<ExceptionBusinessUnit> SelectedExceptionBusinessUnits  { get; set; }
        public ICollection<ExceptionCitation> SelectedExceptionCitations  { get; set; }
        public ICollection<ExceptionCitationLibrary> SelectedExceptionCitationLibrarys  { get; set; }
        public ICollection<ExceptionDocument> SelectedExceptionDocuments  { get; set; }
        public ICollection<ExceptionOrganization> SelectedExceptionOrganizations  { get; set; }
        public ICollection<ExceptionRemediation> SelectedExceptionRemediations  { get; set; }
        public ICollection<ExceptionRiskManagement> SelectedExceptionRiskManagements  { get; set; }
        
    }
}
