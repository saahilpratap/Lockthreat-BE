using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.OrganizationSetup
{
    public interface IOrganizationSetupAppService : IApplicationService
    {
        Task<PagedResultDto<OrganizationSetupListDto>> GetAllOrgnizationSetup(GetOrganizationSetupInput input);
        Task CreateOrUpdateOrganizationSetup(CreateOrUpdateOrganizationSetupInput input);
        Task<long> GetOrganizationByOrganizationUnitId(EntityDto input);
        string GetNextCompanyId();
    }
}
