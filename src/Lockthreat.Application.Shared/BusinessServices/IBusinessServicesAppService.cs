using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.BusinessServices.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.BusinessServices
{
    public interface IBusinessServicesAppService: IApplicationService
    {
        Task<BusinessServiceDto> GetBusinessSerivceInfo(long? ServiceId);
        Task<PagedResultDto<BusinessServicesListDto>> GetAllBusinessServicesList(GetBusinessServicesInput input);
        Task CreateOrUpdateBusinessServices(BusinessServiceDto input);
        Task<GetBusinessServicesForEditDto> GetBusinessServiceForEdit(EntityDto input);
        Task RemoveBusinessService(long ServiceId);


    }
}
