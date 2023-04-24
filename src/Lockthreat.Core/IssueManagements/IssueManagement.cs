using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using Lockthreat.Meetings;
using System;


namespace Lockthreat.IssueManagements
{
   public class IssueManagement  : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string IssueId { get; set; }

        public string IssueTitle { get; set; }
        public string  IssueDetails { get; set; }

        public DateTime? OccuranceDate { get; set; }

        public DateTime? ReportedDate { get; set; }

        public int? MeetingId  { get; set; }

        public Meeting Meeting  { get; set; }


        public int? IssueCategoryId { get; set; }
        public DynamicParameterValue IssueCategory { get; set; }

        public bool RiskAssessmentRequired { get; set; }


        public long? ReporterId  { get; set; }
        public Employee Reporter { get; set; }

        public long?  OwnerId { get; set; }
        public Employee Owner { get; set; }

        public ActionType ActionTypes { get; set; }

        public DateTime? DueDate { get; set; }

        public bool Completed { get; set; }

        public string Title { get; set; }

        public long? CompletedById  { get; set; }
        public Employee CompletedBy { get; set; }

        public string Description { get; set; }

        public DateTime? CompletedDate { get; set; }

        public long? AssignedToId  { get; set; }
        public Employee AssignedTo { get; set; }    


    }
}
