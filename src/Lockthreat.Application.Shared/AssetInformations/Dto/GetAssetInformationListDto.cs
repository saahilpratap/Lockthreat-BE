using Abp.Application.Services.Dto;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.AssetInformations.Dto
{
   public class GetAssetInformationListDto : EntityDto<long>
    {
        public int? TenantId { get; set; }
        public string AssetId { get; set; }
        public string AssetTitle { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }

        public int? AssetIdLV { get; set; }

        public int? AssetTypeId { get; set; }
        public DynamicParameterValue AssetType { get; set; }
        public int? AssetCategoryId { get; set; }
        public DynamicParameterValue AssetCategory { get; set; }

        public int? AssetLabelId { get; set; }
        public DynamicParameterValue AssetLabel { get; set; }

        public long? LockThreatOrganizationId { get; set; }
        public GetOrganizationDto LockThreatOrganization { get; set; }
        public long? EmployeeId { get; set; }
        public BusinessServiceOwner Employee { get; set; }

        public int? ConfidentialityId { get; set; }
        public DynamicParameterValue Confidentiality { get; set; }

        public int? AvailibilityId { get; set; }
        public DynamicParameterValue Availibility { get; set; }

        public int? IntegrityId { get; set; }
        public DynamicParameterValue Integrity { get; set; }
        public int? OtherId { get; set; }
        public DynamicParameterValue Other { get; set; }
    }
}
