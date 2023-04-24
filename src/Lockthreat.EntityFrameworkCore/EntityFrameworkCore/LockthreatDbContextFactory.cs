using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Lockthreat.Configuration;
using Lockthreat.Web;

namespace Lockthreat.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class LockthreatDbContextFactory : IDesignTimeDbContextFactory<LockthreatDbContext>
    {
        public LockthreatDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<LockthreatDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), addUserSecrets: true);

            LockthreatDbContextConfigurer.Configure(builder, configuration.GetConnectionString(LockthreatConsts.ConnectionStringName));

            return new LockthreatDbContext(builder.Options);
        }
    }
}