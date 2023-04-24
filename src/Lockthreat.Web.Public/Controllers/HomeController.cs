using Microsoft.AspNetCore.Mvc;
using Lockthreat.Web.Controllers;

namespace Lockthreat.Web.Public.Controllers
{
    public class HomeController : LockthreatControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}