using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.Employee.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Employee
{
    public interface IEmployeeAppService : IApplicationService
    {
        Task<PagedResultDto<EmployeeListDto>> GetAllEmployees(GetEmployeeInput input);
        Task CreateOrUpdateEmployees(CreateOrUpdateEmployeesInput input);
        Task<GetEmployeeForEditDto> GetEmployeesForEdit(EntityDto input);
        Task DeleteEmployee(EntityDto input);
        string GetNextEmployeeId();
        Task<bool> CheckUserAvailable(string UserName);
        Task<List<GetEmployeeUnderOraganizationDto>> GetEmployeeForOraganization(long orgId);
    }
}
