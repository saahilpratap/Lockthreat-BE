using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Lockthreat
{
    [DependsOn(typeof(LockthreatXamarinSharedModule))]
    public class LockthreatXamarinAndroidModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LockthreatXamarinAndroidModule).GetAssembly());
        }
    }
}