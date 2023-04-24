using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessEntities;
using Lockthreat.Contacts;
using Lockthreat.CyberAwarenessScores;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using Lockthreat.Questions;
using Lockthreat.ReviewAssessments;
using Lockthreat.ReviewsAssessments;
using Lockthreat.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ReviewDatas
{
  public  class ReviewData : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string ReviewId { get; set; }

        public long? ReviewLeadId { get; set; }
        public Employee ReviewLead { get; set; }

        public long? ReviewAssessmentId  { get; set; }
        public ReviewAssessment ReviewAssessment { get; set; }

        public long? CyberAwarenessScoreId { get; set; }
        public CyberAwarenessScore CyberAwarenessScore { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization { get; set; }

        public int? AnswerPoints { get; set; }

        public DateTime? ResponseTime { get; set; }
        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }

        public long? VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public long? ContactsId  { get; set; }
        public Contact  Contacts { get; set; }

        public long? QuestionId  { get; set; }
        public Question Question { get; set; }

        public long? QuestionLibraryId  { get; set; }
        public Question QuestionLibrary  { get; set; }

        public long? QuestionAssignedToId  { get; set; }
        public Employee QuestionAssignedTo { get; set; }

        public string SelectedAnswer { get; set; }

        public string Remarks { get; set; }
        public long? RespondedById  { get; set; }
        public Employee RespondedBy { get; set; }

        public long? VerifierId { get; set; }
        public Employee Verifier  { get; set; }

        public string ReviewFeedback { get; set; }

        public DateTime? VerfiedTime { get; set; }

        public int? ReviewQuestionStatusId  { get; set; }
        public DynamicParameterValue ReviewQuestionStatus { get; set; }
        
        public bool QuestionAnswered { get; set; }
    }
}
