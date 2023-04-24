using System.Threading.Tasks;
using Abp.Application.Services;
using Lockthreat.MultiTenancy.Payments.Dto;
using Lockthreat.MultiTenancy.Payments.Stripe.Dto;

namespace Lockthreat.MultiTenancy.Payments.Stripe
{
    public interface IStripePaymentAppService : IApplicationService
    {
        Task ConfirmPayment(StripeConfirmPaymentInput input);

        StripeConfigurationDto GetConfiguration();

        Task<SubscriptionPaymentDto> GetPaymentAsync(StripeGetPaymentInput input);

        Task<string> CreatePaymentSession(StripeCreatePaymentSessionInput input);
    }
}