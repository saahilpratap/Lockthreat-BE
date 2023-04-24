using System.Threading.Tasks;
using Lockthreat.Authorization.Users;

namespace Lockthreat.WebHooks
{
    public interface IAppWebhookPublisher
    {
        Task PublishTestWebhook();
    }
}
