using System.Threading.Tasks;
using Abp.Webhooks;

namespace Lockthreat.WebHooks
{
    public interface IWebhookEventAppService
    {
        Task<WebhookEvent> Get(string id);
    }
}
