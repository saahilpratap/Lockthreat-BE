using Abp.AspNetCore.Mvc.Authorization;
using Lockthreat.Storage;

namespace Lockthreat.Web.Controllers
{
    [AbpMvcAuthorize]
    public class ProfileController : ProfileControllerBase
    {
        public ProfileController(ITempFileCacheManager tempFileCacheManager) :
            base(tempFileCacheManager)
        {
        }
    }
}