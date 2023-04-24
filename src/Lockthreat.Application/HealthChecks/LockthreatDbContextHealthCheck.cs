using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Lockthreat.EntityFrameworkCore;

namespace Lockthreat.HealthChecks
{
    public class LockthreatDbContextHealthCheck : IHealthCheck
    {
        private readonly DatabaseCheckHelper _checkHelper;

        public LockthreatDbContextHealthCheck(DatabaseCheckHelper checkHelper)
        {
            _checkHelper = checkHelper;
        }

        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
        {
            if (_checkHelper.Exist("db"))
            {
                return Task.FromResult(HealthCheckResult.Healthy("LockthreatDbContext connected to database."));
            }

            return Task.FromResult(HealthCheckResult.Unhealthy("LockthreatDbContext could not connect to database"));
        }
    }
}
