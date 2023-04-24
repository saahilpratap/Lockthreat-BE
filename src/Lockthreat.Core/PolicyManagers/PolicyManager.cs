using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.PolicyManagers
{
    public class PolicyManager : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string PolicyId { get; set; }

        public int? PolicyTypeId { get; set; }
        public DynamicParameterValue PolicyType { get; set; }

        public long? RelatedPoliciesId { get; set; }

        public int? PolicyStatusId { get; set; }
        public DynamicParameterValue PolicyStatus { get; set; }

        public long? PolicyOwnerId { get; set; }
        public Employee PolicyOwner { get; set; }

        public long? PolicyManagersId { get; set; }
        public Employee PolicyManagers { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }

        public string PolicyName { get; set; }

        public string Purpose { get; set; }
        public string PolicyScope { get; set; }
        public string OriginalPolicy { get; set; }

        public string PolicyContent { get; set; }

        public string PolicyDocument { get; set; }
        public long? ApprovalById { get; set; }
        public Employee ApprovalBy { get; set; }

        public string ApproverComments { get; set; }

        public string ApprovedBySignature { get; set; }

        public long? FinalReviewerId { get; set; }
        public Employee FinalReviewer { get; set; }

        public string ReviewerNotes { get; set; }
        public string FinalReviewerSignature { get; set; }

        public DateTime? EffectiveFrom { get; set; }

        public DateTime? UpcomingReview {get;set;}

        public DateTime? EffectiveTo { get; set; }

        public DateTime? ScheduledReview { get; set; }


    }
}
