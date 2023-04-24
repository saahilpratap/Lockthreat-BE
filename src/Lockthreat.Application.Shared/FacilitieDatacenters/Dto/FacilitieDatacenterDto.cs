using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.FacilitieDatacenters
{
  public  class FacilitieDatacenterDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string FacilityId { get; set; }
        public string FacilityName { get; set; }   
        public string FacilityAddressOne { get; set; }
        public string FacilityAddressTwo { get; set; }

        public int? FacilityTypeId  { get; set; }
        public List<GetDynamicValueDto> FacilityTypes  { get; set; }
        public string State { get; set; }

        public string City { get; set; }
        public string  PostalCode { get; set; }
        public int? CountryId { get; set; }
        public List<CountryDto> Countries { get; set; }
        public long? LockThreatOrganizationId  { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; } 
        public long? BusinessUnitOwnerId { get; set; }
        public List<BusinessUnitPrimaryDto> BusinessUnitOwners  { get; set; }
        public long? BusinessUnitGaurdianId  { get; set; }
        public List<BusinessUnitGaurdianDto> BusinessUnitGaurdians   { get; set; }
        public long? EmployeeId  { get; set; }
        public List<BusinessServiceOwner> EmployeesList { get; set; }
        public int? ConfidentialityId { get; set; }
        public List<GetDynamicValueDto> Confidentialitys { get; set; }
        public int? IntegrityId { get; set; }
        public List<GetDynamicValueDto> Integritys  { get; set; }
        public int? AvailibilityId { get; set; }
        public List<GetDynamicValueDto> Availibilitys   { get; set; }
        public int? OthersId { get; set; }
        public List<GetDynamicValueDto> Otheres   { get; set; }
        public List<ITserviceListDto> ITserviceLists { get; set; }
        public List<BusinessServiceSDto> BusinessServices { get; set; }

        public List<BusinessProcessDetailDto> BusinessProcess { get; set; }
        public List<FacilitieDatacenterITServiceDto> SelectedFacilitieDatacenterITServices { get; set; }
        public List<FacilitieDatacenterProcessDto> SelectedFacilitieDatacenterProcess { get; set; }
        public List<FacilitieDatacenterServiceDto> SelectedFacilitieDatacenterServices  { get; set; }
        public List<long> RemovedFacilitieDatacenterITService { get; set; }
        public List<long> RemovedFacilitieDatacenterProcess { get; set; }
        public List<long> RemovedFacilitieDatacenterService { get; set; }

    }

    public class FacilitieDatacenterITServiceDto
    {
        public long Id { get; set; }
        public long? FacilitieDatacenterId { get; set; }
        public long? ITServiceId { get; set; }
    }

    public class FacilitieDatacenterProcessDto
    {
        public long Id { get; set; }
        public long? FacilitieDatacenterId { get; set; }
        public long? BusinessProcessId { get; set; }
    }

    public class FacilitieDatacenterServiceDto
    {
        public long Id { get; set; }
        public long? FacilitieDatacenterId { get; set; }
        public long? BusinessServiceId  { get; set; }
    }

    public class BusinessProcessDetailDto 
    {
        public long Id { get; set; }
        public string BusinessProcessName { get; set; }
    }
}
