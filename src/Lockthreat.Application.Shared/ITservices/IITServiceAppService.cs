using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.ITservices.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.ITservices
{
  public  interface IITServiceAppService : IApplicationService
    {
        Task<List<GetITserviceForBusinessServiceDto>> GetAllITserviceUnderOraganization(long OrgId);
        Task<ITserviceDto> GetITserviceInfo(long? ITserviceId);
        Task<PagedResultDto<GetITserviceListDto>> GetAllITServiceList(GetITserviceInput input);
        Task CreateOrUpdateITservice(ITserviceDto input);
        Task RemoveITService(long ITserviceId);
    }
}
