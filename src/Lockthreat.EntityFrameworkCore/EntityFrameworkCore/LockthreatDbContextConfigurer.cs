using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Lockthreat.EntityFrameworkCore
{
    public static class LockthreatDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<LockthreatDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<LockthreatDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}