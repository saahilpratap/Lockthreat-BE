using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Lockthreat
{
    public class LockthreatCoreSharedModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LockthreatCoreSharedModule).GetAssembly());
        }
    }
}