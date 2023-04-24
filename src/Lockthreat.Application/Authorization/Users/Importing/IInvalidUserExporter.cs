using System.Collections.Generic;
using Lockthreat.Authorization.Users.Importing.Dto;
using Lockthreat.Dto;

namespace Lockthreat.Authorization.Users.Importing
{
    public interface IInvalidUserExporter
    {
        FileDto ExportToFile(List<ImportUserDto> userListDtos);
    }
}
