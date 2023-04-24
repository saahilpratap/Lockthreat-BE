using Abp.AspNetCore.Mvc.ViewComponents;

namespace Lockthreat.Web.Public.Views
{
    public abstract class LockthreatViewComponent : AbpViewComponent
    {
        protected LockthreatViewComponent()
        {
            LocalizationSourceName = LockthreatConsts.LocalizationSourceName;
        }
    }
}