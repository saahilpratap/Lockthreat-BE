using Abp.Dependency;
using GraphQL;
using GraphQL.Types;
using Lockthreat.Queries.Container;

namespace Lockthreat.Schemas
{
    public class MainSchema : Schema, ITransientDependency
    {
        public MainSchema(IDependencyResolver resolver) :
            base(resolver)
        {
            Query = resolver.Resolve<QueryContainer>();
        }
    }
}