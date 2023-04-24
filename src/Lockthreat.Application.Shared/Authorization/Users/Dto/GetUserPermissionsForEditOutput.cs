using System.Collections.Generic;
using Lockthreat.Authorization.Permissions.Dto;

namespace Lockthreat.Authorization.Users.Dto
{
    public class GetUserPermissionsForEditOutput
    {
        public List<FlatPermissionDto> Permissions { get; set; }

        public List<string> GrantedPermissionNames { get; set; }
    }
}