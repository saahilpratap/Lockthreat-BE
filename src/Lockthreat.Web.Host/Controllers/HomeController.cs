using Abp.Auditing;
using Microsoft.AspNetCore.Mvc;

namespace Lockthreat.Web.Controllers
{
    public class HomeController : LockthreatControllerBase
    {
        [DisableAuditing]
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Ui");
        }
    }
}
