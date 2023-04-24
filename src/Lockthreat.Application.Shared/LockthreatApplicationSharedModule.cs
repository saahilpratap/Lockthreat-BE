using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Lockthreat
{
    [DependsOn(typeof(LockthreatCoreSharedModule))]
    public class LockthreatApplicationSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LockthreatApplicationSharedModule).GetAssembly());
        }
    }
}