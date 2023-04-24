using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Vendors
{
    public class VendorInfoDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public string ContactFirstName { get; set; }

        public string ContactLastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string CellPhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }
        public string Address { get; set; }

        public string AddressLine { get; set; }

        public string State { get; set; }
        public string City { get; set; }
        public int? PostalCode { get; set; }

        public int? CountryId { get; set; }
        public List<CountryDto> Countrys { get; set; }

        public int? VendorTypeId { get; set; }
        public List<GetDynamicValueDto> VendorTypes { get; set; }


        public int? IndustryId { get; set; }
        public List<GetDynamicValueDto> Industrys { get; set; }

        public int? VendorCriticalRatingId { get; set; }
        public List<GetDynamicValueDto> VendorCriticalRatings { get; set; }

        public int? VendorInitialRatingId { get; set; }
        public List<GetDynamicValueDto> VendorInitialRatings { get; set; }

        public List<GetDynamicValueDto> VendorProductList { get; set; } 
        public List<VendorProductServiceDto> SelectedVendorProductServices  { get; set; }

    }

    public class VendorProductServiceDto
    {
        public long Id { get; set; }
        public int? VendorServiceId { get; set; }
        public long? VendorId { get; set; }

    }
}
