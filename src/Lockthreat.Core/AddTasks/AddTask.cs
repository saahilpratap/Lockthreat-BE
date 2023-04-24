using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using Lockthreat.Meetings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lockthreat.AddTasks     
{
    [Table("AddTasks")]
    public class AddTask : FullAuditedEntity<long>, IMayHaveTenant
    {
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
        public DynamicParameterValue TaskType { get; set; }

        public int? LinkedToId { get; set; }
        public DynamicParameterValue LinkedTo { get; set; }

        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; }

        public int? RiskLevelId { get; set; }
        public DynamicParameterValue RiskLevel { get; set; }

        public long? RequestedById { get; set; }
        public Employee RequestedBy { get; set; }

        public long? AssignedUserId { get; set; }
        public Employee AssignedUser { get; set; }

        public long? AssignedToId { get; set; }
        public Employee AssignedTo { get; set; }

        public ICollection<TaskAssociatedProject> SelectedAssociatedProjects  { get; set; }

        public ICollection<TaskAttachment> SelectedTaskTaskAttachments  { get; set; }

        public ICollection<TaskNotification> SelectedTaskNotifications  { get; set; }

        public ICollection<TaskRelatedMember> SelectedRelatedMembers  { get; set; }

        public ICollection<MeetingTask> SelectedMeetingTasks  { get; set; }


    }
}
