using System.Threading.Tasks;
using Abp.Application.Services;
using Lockthreat.Editions.Dto;
using Lockthreat.MultiTenancy.Dto;

namespace Lockthreat.MultiTenancy
{
    public interface ITenantRegistrationAppService: IApplicationService
    {
        Task<RegisterTenantOutput> RegisterTenant(RegisterTenantInput input);

        Task<EditionsSelectOutput> GetEditionsForSelect();

        Task<EditionSelectDto> GetEdition(int editionId);
    }
}