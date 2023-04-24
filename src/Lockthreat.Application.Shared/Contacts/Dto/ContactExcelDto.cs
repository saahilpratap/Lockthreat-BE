using Abp.DynamicEntityParameters;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contacts.Dto
{
  public  class ContactExcelDto
    {
        public int? TenantId { get; set; }
        public string ContactId { get; set; }
        public int? ContactTypeId { get; set; }
        public DynamicParameterValue ContactType { get; set; }
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
        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }
        public long? LoginUserId { get; set; }
        public BusinessServiceOwner LoginUser { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public GetOrganizationDto LockThreatOrganization { get; set; }

        public long? VendorId { get; set; }
        public VendorsDto Vendor { get; set; }
    }
}
