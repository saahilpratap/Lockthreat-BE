using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.Authorization.Users.Dto;

namespace Lockthreat.Authorization.Users
{
    public interface IUserLoginAppService : IApplicationService
    {
        Task<ListResultDto<UserLoginAttemptDto>> GetRecentUserLoginAttempts();
    }
}
