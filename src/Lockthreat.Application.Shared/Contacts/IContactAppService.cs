using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.Contacts.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Contacts
{
   public interface IContactAppService : IApplicationService
    {
        Task CreateOrUpdateContact(ContactInfoDto input);
        Task<ContactInfoDto> GetAllContactsInfo(long? ContactId);
        Task<PagedResultDto<ContactListViewDto>> GetAllContactList(ContactInputDto input);
    }
}
