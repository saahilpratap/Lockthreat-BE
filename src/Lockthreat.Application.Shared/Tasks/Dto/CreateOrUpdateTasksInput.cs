using Abp.DynamicEntityParameters;
using Lockthreat.AddTasks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Tasks.Dto
{
    public class CreateOrUpdateTasksInput
    {
        public long? Id { get; set; }
        public int? TenantId { get; set; } 
        public string TaskId { get; set; } 
        public string TaskDescription { get; set; }
        public string TaskTitle { get; set; } 
        public Frequency Frequencys { get; set; } 
        public Priority Prioritys { get; set; } 
        public String Tags { get; set; } 
        public int? Days { get; set; } 
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; } 
        public DateTime? ActualCompleted { get; set; } 
        public int? TaskTypeId { get; set; } 
        public int? LinkedToId { get; set; } 
        public int? StatusId { get; set; } 
        public int? RiskLevelId { get; set; } 
        public long? RequestedById { get; set; } 
        public long? AssignedUserId { get; set; } 
        public long? AssignedToId { get; set; } 
    }
}
