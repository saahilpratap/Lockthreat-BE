using Abp.Authorization;
using Lockthreat.Authorization.Roles;
using Lockthreat.Authorization.Users;

namespace Lockthreat.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
