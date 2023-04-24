using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;

namespace Lockthreat.Startup
{
    [DependsOn(typeof(LockthreatCoreModule))]
    public class LockthreatGraphQLModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LockthreatGraphQLModule).GetAssembly());
        }

        public override void PreInitialize()
        {
            base.PreInitialize();

            //Adding custom AutoMapper configuration
            Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomDtoMapper.CreateMappings);
        }
    }
}