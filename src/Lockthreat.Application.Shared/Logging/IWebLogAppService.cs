using Abp.Application.Services;
using Lockthreat.Dto;
using Lockthreat.Logging.Dto;

namespace Lockthreat.Logging
{
    public interface IWebLogAppService : IApplicationService
    {
        GetLatestWebLogsOutput GetLatestWebLogs();

        FileDto DownloadWebLogs();
    }
}
