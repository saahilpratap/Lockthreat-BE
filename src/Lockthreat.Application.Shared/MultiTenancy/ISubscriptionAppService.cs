using System.Threading.Tasks;
using Abp.Application.Services;

namespace Lockthreat.MultiTenancy
{
    public interface ISubscriptionAppService : IApplicationService
    {
        Task DisableRecurringPayments();

        Task EnableRecurringPayments();
    }
}
