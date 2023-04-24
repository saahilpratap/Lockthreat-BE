using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Lockthreat.MultiTenancy.Accounting.Dto;

namespace Lockthreat.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
