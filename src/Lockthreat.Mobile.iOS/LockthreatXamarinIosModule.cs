using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Lockthreat
{
    [DependsOn(typeof(LockthreatXamarinSharedModule))]
    public class LockthreatXamarinIosModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LockthreatXamarinIosModule).GetAssembly());
        }
    }
}