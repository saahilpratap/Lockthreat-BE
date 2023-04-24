using Abp.Modules;
using Abp.Reflection.Extensions;
using Castle.Windsor.MsDependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Lockthreat.Configure;
using Lockthreat.Startup;
using Lockthreat.Test.Base;

namespace Lockthreat.GraphQL.Tests
{
    [DependsOn(
        typeof(LockthreatGraphQLModule),
        typeof(LockthreatTestBaseModule))]
    public class LockthreatGraphQLTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            IServiceCollection services = new ServiceCollection();
            
            services.AddAndConfigureGraphQL();

            WindsorRegistrationHelper.CreateServiceProvider(IocManager.IocContainer, services);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LockthreatGraphQLTestModule).GetAssembly());
        }
    }
}