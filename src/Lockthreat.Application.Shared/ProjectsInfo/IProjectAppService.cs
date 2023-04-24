using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.ProjectsInfo.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.ProjectsInfo
{
    public interface IProjectAppService : IApplicationService
    {
        Task<ProjectDto> GetProjectInfo(long? projectId);

        Task AddorEditProject(ProjectDto project);

        Task RemoveProjectTeamMember(long id);

        Task RemoveProjectTeamMemberInternal(long id);

        Task RemoveProjectTeamMemberExternal(long id);

        Task RemoveProjectCountry(long id);

        Task RemoveProjectAuthoratativeDocument(long id);

        Task RemoveProjectComponents(long id);

        Task RemoveProject(long projectId);

        Task<PagedResultDto<ProjectListDto>> GetAllProjects(ProjectListInput input);
    }
}
