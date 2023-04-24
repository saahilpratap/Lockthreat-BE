using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.Audits.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Audits
{
 public  interface IAuditAppService : IApplicationService
    {
        Task<AuditDto> GetAllAuditInfoDetails(long? auditId);
        Task CreateOrUpdateAudit(AuditDto input);
        Task<PagedResultDto<GetAuditListDto>> GetAllAuditList(GetAuditInputDto input);

        Task RemoveAudit(long hardwareAssetId);
    }
}
