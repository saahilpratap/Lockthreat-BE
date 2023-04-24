using System.Threading.Tasks;
using Abp.Application.Services;
using Lockthreat.MultiTenancy.Payments.PayPal.Dto;

namespace Lockthreat.MultiTenancy.Payments.PayPal
{
    public interface IPayPalPaymentAppService : IApplicationService
    {
        Task ConfirmPayment(long paymentId, string paypalOrderId);

        PayPalConfigurationDto GetConfiguration();
    }
}
