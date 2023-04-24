using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Tasks.Dto
{
    public class TaskListDto : EntityDto<long>, IPassivable, IHasCreationTime
    {
        public string TaskId { get; set; } 
        public string TaskTitle { get; set; }
        public long? RequestedById { get; set; }
        public GetEmployeeForEditDto RequestedBy { get; set; }
        public int? TaskTypeId { get; set; }
        public DynamicParameterValue TaskType { get; set; }
        public long? AssignedUserId { get; set; }
        public GetEmployeeForEditDto AssignedUser { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
