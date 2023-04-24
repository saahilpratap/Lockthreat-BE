using Abp.Domain.Entities.Auditing;
using Lockthreat.AddTasks;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.UploadFiles.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Tasks.Dto
{
 public class TaskinfoDto : FullAuditedEntity<long>
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
        public List<GetDynamicValueDto> TaskTypes  { get; set; }
        public int? LinkedToId { get; set; }
        public List<GetDynamicValueDto> LinkedList    { get; set; }
        public int? StatusId { get; set; }
        public List<GetDynamicValueDto>  Statuses  { get; set; }
        public int? RiskLevelId { get; set; }
        public List<GetDynamicValueDto> RiskLevels  { get; set; }
        public long? RequestedById { get; set; }
        public List<BusinessServiceOwner> RequestedList { get; set; }
        public long? AssignedUserId { get; set; }
        public List<BusinessServiceOwner> AssignedUserList  { get; set; }
        public long? AssignedToId { get; set; }
        public List<BusinessServiceOwner> AssignedToList  { get; set; }

        public List<ProjectListsDto> ProjectList { get; set; }

        public List<MeetingsDto> MeetingList { get; set; }
        public List<TaskAssociatedProjectDto> SelectedAssociatedProjects  { get; set; }
        public List<long> RemovedAssociatedProjects  { get; set; }
        public List<TaskRelatedMemberDto> SelectedRelatedMembers  { get; set; }
        public List<long> RemovedRelatedMembers  { get; set; }
        public List<TaskNotificationDto> SelectedTaskNotifications  { get; set; }
        public List<long> RemovedNotifications  { get; set; }
        public List<TaskAttachmentDto> SelectedTaskTaskAttachments  { get; set; }

        public List<UploadFileDto> UploadFiles { get; set; }
        public List<long> RemovedTaskTaskAttachments  { get; set; }
        public List<MeetingTaskDto> SelectedMeetingTasks   { get; set; }

        public List<long> RemovedMeetingTasks  { get; set; }

    }

    public class TaskAssociatedProjectDto
    {
        public long Id { get; set; }
        public long? AddTaskId { get; set; }

        public long? ProjectId { get; set; }
    }

    public class TaskRelatedMemberDto
    {
        public long Id { get; set; }
        public long? AddTaskId { get; set; }
        public long? EmployeeId { get; set; }
    }

    public class TaskNotificationDto
    {
        public long Id { get; set; }
        public long? AddTaskId { get; set; }
        public long? EmployeeId { get; set; }
    }

    public class TaskAttachmentDto
    {
        public long Id { get; set; }
        public long? AddTaskId { get; set; }
        public string Document { get; set; }
    }

    public  class MeetingTaskDto
    {
        public long Id { get; set; }
        public long? AddTaskId { get; set; }
        public long? MeetingId { get; set; }

    }

    public class ProjectListsDto 
    {
        public long Id { get; set; }
        public string ProjectName { get; set; }
    }

    public class MeetingsDto 
    {
        public long Id { get; set; }     
        public string MeetingTitle { get; set; }
    }
}
