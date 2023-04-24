using Microsoft.Extensions.Configuration;

namespace Lockthreat.Configuration
{
    public interface IAppConfigurationAccessor
    {
        IConfigurationRoot Configuration { get; }
    }
}
