using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.Authorization.Permissions.Dto;

namespace Lockthreat.Authorization.Permissions
{
    public interface IPermissionAppService : IApplicationService
    {
        ListResultDto<FlatPermissionWithLevelDto> GetAllPermissions();
    }
}
