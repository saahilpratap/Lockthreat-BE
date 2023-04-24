using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using Lockthreat.Questions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.ReviewAssessments 
{
  public  class ReviewAssessment : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string ReviewId { get; set; }

        public string  Summary { get; set; }
        [Required]
        public string  ReviewTitle { get; set; }

        public int? ReviewTypeId  { get; set; }
        public DynamicParameterValue ReviewType { get; set; }

        public long? AssignedToId  { get; set; }
        public Employee AssignedTo { get; set; }

        public int? ScheduleId  { get; set; }
        public DynamicParameterValue Schedule { get; set; }
        
        public int? EveryDays { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime?  PeriodicReviewEndDate { get; set; }


        public long? QuestionId  { get; set; }

        public Question Question  { get; set; }




    }
}
