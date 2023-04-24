using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lockthreat.MultiTenancy.HostDashboard.Dto;

namespace Lockthreat.MultiTenancy.HostDashboard
{
    public interface IIncomeStatisticsService
    {
        Task<List<IncomeStastistic>> GetIncomeStatisticsData(DateTime startDate, DateTime endDate,
            ChartDateInterval dateInterval);
    }
}