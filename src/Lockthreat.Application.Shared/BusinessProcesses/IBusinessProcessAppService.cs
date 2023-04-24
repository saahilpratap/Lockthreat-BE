using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.BusinessProcesses.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.BusinessProcesses
{
    public interface IBusinessProcessAppService: IApplicationService
    {
        Task<BusinessProcessDto> GetAllBusinessprocessInfo(long? businessProcessId);
        Task<PagedResultDto<BusinessProcessListDto>> GetAllBusinessProcessList(GetBusinessProcessInput input);
        Task CreateOrUpdateBusinessProcess(BusinessProcessDto input);
        Task<GetBusinessProcessForEditDto> GetBusinessProcessForEdit(EntityDto input);
        Task RemoveBusinesProcess(long BusinessProcessId);
        string GetNextBusinessProcessId();
    }
}
