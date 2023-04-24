using Abp.Modules;
using Lockthreat.Test.Base;

namespace Lockthreat.Tests
{
    [DependsOn(typeof(LockthreatTestBaseModule))]
    public class LockthreatTestModule : AbpModule
    {
       
    }
}
