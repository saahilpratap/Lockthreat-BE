using Abp.DynamicEntityParameters;
using Lockthreat.AddTasks;
using Lockthreat.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Tasks.Dto
{
    public class GetTasksForEditDto
    {
        public int? Id { get; set; }
        public int? TenantId { get; set; } 
        public string TaskId { get; set; } 
        public string TaskDescription { get; set; }
        public string TaskTitle { get; set; } 
        public Frequency Frequencys { get; set; } 
        public Priority Prioritys { get; set; } 
        public string Tags { get; set; } 
        public int? Days { get; set; } 
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; } 
        public DateTime? ActualCompleted { get; set; } 
        public int? TaskTypeId { get; set; }
        public DynamicParameterValue TaskType { get; set; } 
        public int? LinkedToId { get; set; }
        public DynamicParameterValue LinkedTo { get; set; } 
        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; } 
        public int? RiskLevelId { get; set; }
        public DynamicParameterValue RiskLevel { get; set; } 
        public long? RequestedById { get; set; }
        public GetEmployeeForEditDto RequestedBy { get; set; } 
        public long? AssignedUserId { get; set; }
        public GetEmployeeForEditDto AssignedUser { get; set; } 
        public long? AssignedToId { get; set; }
        public GetEmployeeForEditDto AssignedTo { get; set; }
    }
}
