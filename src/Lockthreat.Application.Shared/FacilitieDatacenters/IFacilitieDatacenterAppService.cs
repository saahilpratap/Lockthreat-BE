using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.FacilitieDatacenters.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.FacilitieDatacenters
{
   public interface IFacilitieDatacenterAppService : IApplicationService
    {
        Task<FacilitieDatacenterDto> GetAllFacilitieDatacenterInfo(long? facilitieDatacenterId);
        Task CreateOrUpdateFacilitieDatacenter(FacilitieDatacenterDto input);

        Task<PagedResultDto<GetFacilitiesDatacenterListDto>> GetAllFacilitiesDatacenterList(GetFacilitiesDatacenterInput input);

        Task RemoveFacilitieDatacenter(long facilitieDatacenterId);
    }
}
