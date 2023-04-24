using System.Collections.Generic;
using Lockthreat.Authorization.Users.Importing.Dto;
using Abp.Dependency;

namespace Lockthreat.Authorization.Users.Importing
{
    public interface IUserListExcelDataReader: ITransientDependency
    {
        List<ImportUserDto> GetUsersFromExcel(byte[] fileBytes);
    }
}
