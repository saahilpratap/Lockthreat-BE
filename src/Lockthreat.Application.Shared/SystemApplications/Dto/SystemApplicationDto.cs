using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.SystemApplications.Dto
{
 public  class SystemApplicationDto : FullAuditedEntity<long>
      {
        public int? TenantId { get; set; }
        public string SystemId { get; set; }
        public string SystemApplicationName { get; set; }
        public string AddressOne { get; set; }
        public string AddressTwo { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public int? CountryId { get; set; }
        public List<CountryDto> Countries { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; }
        public long? BusinessUnitId { get; set; }
        public List<BusinessUnitPrimaryDto> BusinessUnits  { get; set; }
        public long? BusinessOwnerId { get; set; }
        public List<BusinessServiceOwner> EmployeesList { get; set; }

        public long? BusinessUnitGaurdianId { get; set; }
        public List<BusinessUnitGaurdianDto> BusinessUnitGaurdians { get; set; }
        public int? ConfidentialityId { get; set; }
        public List<GetDynamicValueDto> Confidentialitys { get; set; }
        public int? AvailibilityId { get; set; }
        public List<GetDynamicValueDto> Availibilitys  { get; set; }
        public int? IntegrityId { get; set; }
        public List<GetDynamicValueDto> Integritys  { get; set; }
        public int? OthersId { get; set; }
        public List<GetDynamicValueDto> Otheres  { get; set; }
        public List<ITserviceListDto> ITserviceLists { get; set; }
        public List<BusinessServiceSDto> BusinessServices { get; set; }
        public List<BusinessProcessDetailDto> BusinessProcess { get; set; }
        public List<SysteamApplicationITserviceDto> SelectedSysteamApplicationITservices  { get; set; }
        public List<SysteamApplicationBusinessProcessDto> SelectedSysteamApplicationBusinessProcess  { get; set; }
        public List<SystemApplicationServiceDto> SelectedSystemApplicationServices  { get; set; }
        public List<long> RemovedSysteamApplicationITservice  { get; set; }
        public List<long> RemovedSysteamApplicationBusinessProcess { get; set; }
        public List<long> RemovedSystemApplicationService  { get; set; }
    }

    public class SysteamApplicationITserviceDto
    {
        public long Id { get; set; }
        public long? SystemApplicationId { get; set; }
        public long? ITServiceId { get; set; }
    }
    public class SysteamApplicationBusinessProcessDto
    {
        public long Id { get; set; }
        public long? SystemApplicationId { get; set; }
        public long? BusinessProcessId { get; set; }
    }
    public class SystemApplicationServiceDto
    {
        public long Id { get; set; }
        public long? SystemApplicationId { get; set; }
        public long? BusinessServiceId { get; set; }
    }

    public class SytemApplicationDto
    {
        public long Id { get; set; }
        public string SystemApplicationName { get; set; }

    }
}
