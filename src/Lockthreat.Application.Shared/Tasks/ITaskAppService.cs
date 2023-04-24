using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.Tasks.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Tasks
{
    public interface ITaskAppService: IApplicationService
    {
        Task<PagedResultDto<TaskListDto>> GetAllTasksList(GetTasksInput input);
        Task CreateorEditTask(TaskinfoDto task);
        Task<TaskinfoDto> GetTaskinfo(long? TaskId);
        Task RemoveTask(long taskId);
    }
}
