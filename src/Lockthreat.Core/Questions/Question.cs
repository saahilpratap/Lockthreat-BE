using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.Questions 
{
 public   class Question : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string QuestionId { get; set; }
        [Required]

        public string QuestionnaireTitle { get; set; }

        public string SourceQuestion { get; set; }

        public string DisplayQuestion { get; set; }

        public string QuestionTitle  { get; set; }

        public int? SectionId  { get; set; }
        public DynamicParameterValue Section  { get; set; }

        public int? QuestionAreaId  { get; set; }
        public DynamicParameterValue QuestionArea { get; set; }

        public int? QuestionCategoryId  { get; set; }
        public DynamicParameterValue QuestionCategory { get; set; }

        public int? QuestionStatusId  { get; set; }
        public DynamicParameterValue QuestionStatus  { get; set; }

        public int? AnswerTypeId  { get; set; }
        public DynamicParameterValue AnswerType { get; set; }

        public bool AnswerTypes { get; set; }

        public string AnswerValues { get; set; }

        public string AnswerText { get; set; }

        public int? AnswerPoints { get; set; }

        public int? TotalPoints { get; set; }

    }
}
