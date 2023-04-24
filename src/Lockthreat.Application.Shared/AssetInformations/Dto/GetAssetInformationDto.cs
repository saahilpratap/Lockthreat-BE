using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.AssetInformations.Dto
{
 public   class GetAssetInformationDto : FullAuditedEntity<long>
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
        public List<CountryDto> Countries { get; set; }
        public int? AssetIdLV { get; set; }
        public int? AssetTypeId { get; set; }
        public List<GetDynamicValueDto> AssetTypes  { get; set; }
        public int? AssetCategoryId { get; set; }
        public List<GetDynamicValueDto> AssetCategorys  { get; set; }
        public int? AssetLabelId { get; set; }
        public List<GetDynamicValueDto> AssetLabels  { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; }
        public long? BusinessUnitOwnerId { get; set; }
        public List<BusinessUnitPrimaryDto> BusinessUnitOwners { get; set; }
        public long? BusinessUnitGaurdianId { get; set; }
        public List<BusinessUnitGaurdianDto> BusinessUnitGaurdians { get; set; }
        public long? EmployeeId { get; set; }
        public List<BusinessServiceOwner> EmployeesList { get; set; }
        public int? ConfidentialityId { get; set; }
        public List<GetDynamicValueDto> Confidentialitys { get; set; }
        public int? AvailibilityId { get; set; }
        public List<GetDynamicValueDto> Availibilitys { get; set; }
        public int? IntegrityId { get; set; }
        public List<GetDynamicValueDto> Integritys { get; set; }
        public int? OtherId { get; set; }
        public List<GetDynamicValueDto> Otheres { get; set; }
        public List<ITserviceListDto> ITserviceLists { get; set; }
        public List<BusinessServiceSDto> BusinessServices { get; set; }
        public List<BusinessProcessDetailDto> BusinessProcess { get; set; }
        public List<AssetInformationITserviceDto> SelectedAssetInformationITservices  { get; set; }
        public List<AssetInformationBusinessprocessDto> SelectedAssetInformationBusinessprocess  { get; set; }
        public List<AssetInformationBusinessServiceDto> SelectedAssetInformationBusinessServices   { get; set; }
        public List<long> RemovedAssetInformationITservice { get; set; }
        public List<long> RemovedAssetInformationBusinessprocess  { get; set; }
        public List<long> RemovedAssetInformationBusinessService  { get; set; }
         
    }
    public class AssetInformationITserviceDto
    {
        public long Id { get; set; }
        public long? AssetInformatinId   { get; set; }
        public long? ITServiceId { get; set; }
    } 
    public class AssetInformationBusinessprocessDto
    {
        public long Id { get; set; }
        public long? AssetInformatinId { get; set; }
        public long? BusinessProcessId { get; set; }
    }
    public class AssetInformationBusinessServiceDto 
    {
        public long Id { get; set; }
        public long? AssetInformatinId { get; set; }
        public long? BusinessServiceId { get; set; }
    }

}
