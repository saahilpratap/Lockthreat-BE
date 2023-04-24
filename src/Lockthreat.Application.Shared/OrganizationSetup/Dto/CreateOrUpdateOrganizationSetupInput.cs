using Lockthreat.Organization;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.OrganizationSetup.Dto
{
   public class CreateOrUpdateOrganizationSetupInput
    {
        public long? Id { get; set; }
        public int? TenantId { get; set; } 
        public string CompanyId { get; set; } 
        public string CompanyName { get; set; } 
        public LevelType Leveltype { get; set; } 
        public virtual long? OrganizationUnitId { get; set; }
        public virtual long? ParentOrganizationId { get; set; } 
        public int? IndustrySectorId { get; set; } 
        public bool IsAuditableEntity { get; set; }
        public string Description { get; set; } 
        public int? CountryId { get; set; } 
        public int? EmployeeSize { get; set; } 
        public string CompanyWebsite { get; set; } 
        public string CompanyLogo { get; set; } //..This field store base64 string  
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; } 
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; } 
        public int? AddressCountryId { get; set; }  
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; } 
        public string JobTitle { get; set; } 
        public string Email { get; set; } 
        public string Phone { get; set; } 
        public string Fax { get; set; } 
        public long? PrimaryContactId { get; set; } 
        public long? CompanyAdministratorId { get; set; } 
        public bool IsActive { get; set; }
    }
}
