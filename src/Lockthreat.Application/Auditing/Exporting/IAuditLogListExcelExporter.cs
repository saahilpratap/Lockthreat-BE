using System.Collections.Generic;
using Lockthreat.Auditing.Dto;
using Lockthreat.Dto;

namespace Lockthreat.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);

        FileDto ExportToFile(List<EntityChangeListDto> entityChangeListDtos);
    }
}
