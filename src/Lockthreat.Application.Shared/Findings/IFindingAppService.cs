using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.Findings.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Findings
{
   public interface IFindingAppService : IApplicationService
    {
        Task<PagedResultDto<FindingListDto>> GetAllFindingList (FindingInputDto input);
        Task<FindingInfoDto> GetAllfindingInfo (long? findingId);
        Task CreateOrUpdateFinding(FindingInfoDto input);
        Task RemoveFinding(long findingId);

    }
}
