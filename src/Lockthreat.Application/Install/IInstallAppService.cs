using System.Threading.Tasks;
using Abp.Application.Services;
using Lockthreat.Install.Dto;

namespace Lockthreat.Install
{
    public interface IInstallAppService : IApplicationService
    {
        Task Setup(InstallDto input);

        AppSettingsJsonDto GetAppSettingsJson();

        CheckDatabaseOutput CheckDatabase();
    }
}