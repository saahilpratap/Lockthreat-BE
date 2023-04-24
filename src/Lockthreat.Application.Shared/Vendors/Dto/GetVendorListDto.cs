using Abp.Application.Services.Dto;
using Abp.DynamicEntityParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Vendors.Dto
{
  public  class GetVendorListDto : EntityDto<long>
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
        public DynamicParameterValue Country { get; set; }
        public int? VendorTypeId { get; set; }
        public DynamicParameterValue VendorType { get; set; }
        public int? IndustryId { get; set; }
        public DynamicParameterValue Industry { get; set; }
        public int? VendorCriticalRatingId { get; set; }
        public DynamicParameterValue VendorCriticalRating { get; set; }
        public int? VendorInitialRatingId { get; set; }
        public DynamicParameterValue VendorInitialRating { get; set; }
    }
}
