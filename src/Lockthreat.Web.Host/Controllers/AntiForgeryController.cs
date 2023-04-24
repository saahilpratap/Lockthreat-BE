using Microsoft.AspNetCore.Antiforgery;

namespace Lockthreat.Web.Controllers
{
    public class AntiForgeryController : LockthreatControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
