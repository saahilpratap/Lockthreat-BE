using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.KeyPerformanceIndicator.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.KeyPerformanceIndicator
{
    public interface IKeyPerformanceIndicatorAppService: IApplicationService
    {
        Task<KeyPerformanceDto> GetKeyperformanceInfo (long? KeyPerformanceId);
        Task<PagedResultDto<KeyPerformanceIndicatorListDto>> GetAllKeyperformanceList (GetKeyPerformanceIndicatorInput input);

       Task CreateorUpdateKeyPerformance(KeyPerformanceDto input);
       Task RemoveKeyPerformances(long KeyPerformanceId);
    }
}
