using System.Threading.Tasks;
using Lockthreat.Sessions.Dto;

namespace Lockthreat.Web.Session
{
    public interface IPerRequestSessionCache
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformationsAsync();
    }
}
