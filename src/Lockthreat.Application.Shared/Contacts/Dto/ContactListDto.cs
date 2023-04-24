using Abp.Application.Services.Dto;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contacts.Dto
{
   public class ContactListDto : EntityDto<long>
    {
        public int? TenantId { get; set; }
        public string ContactId { get; set; }     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string jobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }      
        public string ProfilePicture { get; set; }
    }

    public class ContactListViewDto : EntityDto<long>
    {
        public int? TenantId { get; set; }
        public string ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string jobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string ProfilePicture { get; set; }
        public string ContactType { get; set; }       
        public string Country { get; set; }           
        public string LoginUser { get; set; }     
        public string LockThreatOrganization { get; set; }        
        public string Vendor { get; set; }
    }
}
