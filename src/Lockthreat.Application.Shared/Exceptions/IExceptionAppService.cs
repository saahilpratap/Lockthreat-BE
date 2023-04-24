using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.Exceptions.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Exceptions
{
    public interface IExceptionAppService : IApplicationService
    {
        Task<PagedResultDto<GetExceptionListDto>> GetAllExceptionList(ExceptionInputDto input);
        Task<GetExceptionInfoDto> GetAllException(long? exceptionId);
        Task CreateOrUpdateException(GetExceptionInfoDto input);
        Task RemoveException(long exceptionId);
    }
}
