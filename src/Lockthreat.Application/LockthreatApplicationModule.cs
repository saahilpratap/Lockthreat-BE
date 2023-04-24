using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Lockthreat.Authorization;

namespace Lockthreat
{
    /// <summary>
    /// Application layer module of the application.
    /// </summary>
    [DependsOn(
        typeof(LockthreatApplicationSharedModule),
        typeof(LockthreatCoreModule)
        )]
    public class LockthreatApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            //Adding authorization providers
            Configuration.Authorization.Providers.Add<AppAuthorizationProvider>();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LockthreatApplicationModule).GetAssembly());
        }
    }
}