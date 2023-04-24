using Microsoft.AspNetCore.Mvc;
using Lockthreat.Web.Controllers;

namespace Lockthreat.Web.Public.Controllers
{
    public class AboutController : LockthreatControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}