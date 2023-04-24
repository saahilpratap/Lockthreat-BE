using System.Threading.Tasks;
using Abp.Application.Services;
using Lockthreat.Sessions.Dto;

namespace Lockthreat.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();

        Task<UpdateUserSignInTokenOutput> UpdateUserSignInToken();
    }
}
