using Abp.Domain.Services;

namespace Lockthreat
{
    public abstract class LockthreatDomainServiceBase : DomainService
    {
        /* Add your common members for all your domain services. */

        protected LockthreatDomainServiceBase()
        {
            LocalizationSourceName = LockthreatConsts.LocalizationSourceName;
        }
    }
}
