using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Lockthreat
{
    [DependsOn(typeof(LockthreatClientModule), typeof(AbpAutoMapperModule))]
    public class LockthreatXamarinSharedModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Localization.IsEnabled = false;
            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LockthreatXamarinSharedModule).GetAssembly());
        }
    }
}