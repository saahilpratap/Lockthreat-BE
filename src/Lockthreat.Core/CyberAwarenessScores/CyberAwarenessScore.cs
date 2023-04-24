using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.CyberAwarenessScores 
{
 public  class CyberAwarenessScore : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string CASId { get; set; }
        [Required]
        public string CASName { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee { get; set; }
        
        public int? TargetTypeId { get; set; }
        public DynamicParameterValue TargetType { get; set; }
        public int? SatusId { get; set; }
        public DynamicParameterValue Status { get; set; }
        public int? SourceId { get; set; }
        public DynamicParameterValue Source { get; set; }
        public int? ScheduleId { get; set; }
        public DynamicParameterValue Schedule { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsQuestionarieGenerated { get; set; }

        //dont have sufficient information
        //public string RelatedQuestionarries { get; set; }
    }
}
