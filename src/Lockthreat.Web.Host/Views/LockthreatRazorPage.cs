using Abp.AspNetCore.Mvc.Views;

namespace Lockthreat.Web.Views
{
    public abstract class LockthreatRazorPage<TModel> : AbpRazorPage<TModel>
    {
        protected LockthreatRazorPage()
        {
            LocalizationSourceName = LockthreatConsts.LocalizationSourceName;
        }
    }
}
