using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contacts.Dto
{
  public  class ContactInfoDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string ContactId { get; set; }
        public int? ContactTypeId { get; set; }
        public List<GetDynamicValueDto> ContactTypes  { get; set; }
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
        public List<CountryDto> Countries { get; set; }

        public long? LoginUserId { get; set; }
        public List<BusinessServiceOwner> EmployeesList { get; set; }

        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; }

        public long? VendorId { get; set; }
        public List<VendorsDto> Vendors { get; set; }

        public string ProfilePicture { get; set; }
    }

    public class VendorsDto
    {
        public long? Id  { get; set; }

        public string VendorName { get; set; }
    }
}
