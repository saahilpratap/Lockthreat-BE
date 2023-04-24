using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.KeyRiskIndicator.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.KeyRiskIndicator
{
    public interface IKeyRiskIndicatorsAppService: IApplicationService
    {
        Task<KeyRiskIndicatorDto> GetKeyRiskIndicatorInfo(long? KeyRiskIndicatorsId);
        Task<PagedResultDto<KeyRiskIndicatorListDto>> GetKeyRiskIndicatorList (GetKeyRiskIndicatorInput input);
        Task CreateorUpdateKeyRiskIndicator(KeyRiskIndicatorDto input);
        Task RemoveKeyRiskIndicator(long keyRiskIndicatorId);
    }
}
