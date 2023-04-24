using System.Threading.Tasks;
using Abp.Application.Services;
using Lockthreat.Configuration.Host.Dto;

namespace Lockthreat.Configuration.Host
{
    public interface IHostSettingsAppService : IApplicationService
    {
        Task<HostSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(HostSettingsEditDto input);

        Task SendTestEmail(SendTestEmailInput input);
    }
}
