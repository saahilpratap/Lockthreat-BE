using Abp.Application.Services;
using Lockthreat.OrganizationDashboard.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.OrganizationDashboard
{
    public interface IOrganizationDashboardAppService : IApplicationService
    {
        Task<OrganizationCountDto> GetOrganizationDashboardCount();
    }
}
