using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Abp.Organizations;
using Lockthreat.Countries;
using Lockthreat.IndustrySectors;
using Lockthreat.Organization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.OrganizationSetups 
{
    [Table("LockThreatOrganizations")]
    public class LockThreatOrganization : FullAuditedEntity<long>, IMayHaveTenant, IMayHaveOrganizationUnit
    {

        public int? TenantId { get; set; }

        [Required]
        public string CompanyId { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public LevelType Leveltype { get; set; }

        public virtual long? OrganizationUnitId { get; set; }
        public virtual long? ParentOrganizationId { get; set; }

     
        public int? IndustrySectorId { get; set; }
        public DynamicParameterValue IndustrySector { get; set; }


        public bool IsAuditableEntity { get; set; }
        public string Description { get; set; }


        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }

        public int EmployeeSize { get; set; }

        public string CompanyWebsite { get; set; }

        public string CompanyLogo { get; set; } //..This field store base64 string 

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }

        public int? AddressCountryId { get; set; }
        public DynamicParameterValue AddressCountry { get; set; }

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
