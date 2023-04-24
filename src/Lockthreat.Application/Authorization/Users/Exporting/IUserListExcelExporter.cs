using System.Collections.Generic;
using Lockthreat.Authorization.Users.Dto;
using Lockthreat.Dto;

namespace Lockthreat.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}