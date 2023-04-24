using Abp.Application.Services.Dto;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Exceptions.Dto
{
 public   class GetExceptionListDto : EntityDto<long>
    {
        public int? TenantId { get; set; }
        public string ExceptionId { get; set; }
        public DateTime? RequestedDate { get; set; }
        public string BusinessJustification { get; set; }
        public string ExceptionTitle { get; set; }
        public string Comments { get; set; }
        public long? ExpertReviewerId { get; set; }
        public BusinessServiceOwner ExpertReviewer { get; set; }

        public DateTime? RequestedTillDate { get; set; }
        public DateTime? ReviewDate { get; set; }

        public DateTime? ApprovedTill { get; set; }

        public DateTime? NextReview { get; set; }

        public string RiskDetails { get; set; }

        public int? CritcalityId { get; set; }
        public DynamicParameterValue Critcality { get; set; }

        public int? ReviewPriorityId { get; set; }
        public DynamicParameterValue ReviewPriority { get; set; }

        public int? TypeId { get; set; }
        public DynamicParameterValue Type { get; set; }

        public int? ExceptionStatusId { get; set; }
        public DynamicParameterValue ExceptionStatus { get; set; }

        public int? ReviewStatusId { get; set; }
        public DynamicParameterValue ReviewStatus { get; set; }


        public long? LockThreatOrganizationId { get; set; }
        public GetOrganizationForEditDto LockThreatOrganization { get; set; }

        public long? EmployeeId { get; set; }
        public BusinessServiceOwner  Employee { get; set; }

        public long? BusinessUnitId { get; set; }
        public BusinessUnitPrimaryDto  BusinessUnit { get; set; }

     

    }
}
