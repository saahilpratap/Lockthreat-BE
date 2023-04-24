using System.Collections.Generic;
using Abp;
using Lockthreat.Chat.Dto;
using Lockthreat.Dto;

namespace Lockthreat.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
