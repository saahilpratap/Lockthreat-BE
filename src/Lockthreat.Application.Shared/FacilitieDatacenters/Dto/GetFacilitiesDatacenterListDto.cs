using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Employee.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.FacilitieDatacenters.Dto
{
   public  class GetFacilitiesDatacenterListDto : EntityDto<long>
    {
        public int? TenantId { get; set; }
        public string FacilityId { get; set; }
        public string FacilityName { get; set; }
        public string FacilityAddressOne { get; set; }
        public string FacilityAddressTwo { get; set; }

        public int? FacilityTypeId { get; set; }
        public DynamicParameterValue FacilityType { get; set; }
        public string State { get; set; }

        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }

        public long? LockThreatOrganizationId { get; set; }
        public GetOrganizationForEditDto LockThreatOrganization { get; set; }
        public long? BusinessUnitOwnerId { get; set; }
        public BusinessUnitPrimaryDto BusinessUnitOwner { get; set; }

        public long? BusinessUnitGaurdianId { get; set; }
        public BusinessUnitPrimaryDto BusinessUnitGaurdian { get; set; }

        public int? ConfidentialityId { get; set; }
        public DynamicParameterValue Confidentiality { get; set; }
        public int? IntegrityId { get; set; }
        public DynamicParameterValue Integrity { get; set; }
        public int? AvailibilityId { get; set; }
        public DynamicParameterValue Availibility { get; set; }
        public int? OthersId { get; set; }
        public DynamicParameterValue Others { get; set; }

    }
}
