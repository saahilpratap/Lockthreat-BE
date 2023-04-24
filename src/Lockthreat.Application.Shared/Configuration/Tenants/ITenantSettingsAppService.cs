using System.Threading.Tasks;
using Abp.Application.Services;
using Lockthreat.Configuration.Tenants.Dto;

namespace Lockthreat.Configuration.Tenants
{
    public interface ITenantSettingsAppService : IApplicationService
    {
        Task<TenantSettingsEditDto> GetAllSettings();

        Task UpdateAllSettings(TenantSettingsEditDto input);

        Task ClearLogo();

        Task ClearCustomCss();
    }
}
