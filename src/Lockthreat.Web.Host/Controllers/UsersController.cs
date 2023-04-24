using Abp.AspNetCore.Mvc.Authorization;
using Lockthreat.Authorization;
using Lockthreat.Storage;
using Abp.BackgroundJobs;

namespace Lockthreat.Web.Controllers
{
    [AbpMvcAuthorize(AppPermissions.Pages_Administration_Users)]
    public class UsersController : UsersControllerBase
    {
        public UsersController(IBinaryObjectManager binaryObjectManager, IBackgroundJobManager backgroundJobManager)
            : base(binaryObjectManager, backgroundJobManager)
        {
        }
    }
}