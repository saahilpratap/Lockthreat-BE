using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.Common.Dto;
using Lockthreat.Editions.Dto;

namespace Lockthreat.Common
{
    public interface ICommonLookupAppService : IApplicationService
    {
        Task<ListResultDto<SubscribableEditionComboboxItemDto>> GetEditionsForCombobox(bool onlyFreeItems = false);

        Task<PagedResultDto<NameValueDto>> FindUsers(FindUsersInput input);

        GetDefaultEditionNameOutput GetDefaultEditionName();
    }
}