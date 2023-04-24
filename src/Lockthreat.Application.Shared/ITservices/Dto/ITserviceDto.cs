using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ITservices.Dto
{
 public class ITserviceDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string ITServicesId { get; set; }      
        public string ITServiceName { get; set; }
        public int? ServiceTypeId { get; set; }
        public List<GetDynamicValueDto> ServiceTypes  { get; set; }
        public int? ServiceClassificationId { get; set; }
        public List<GetDynamicValueDto> ServiceClassifications  { get; set; }
        public string AddressLineOne { get; set; }
        public string AddressLineTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int? CountryId { get; set; }
        public List<CountryDto> Countries { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; }
        public long? ITServiceOwnerId { get; set; }
        public List<BusinessServiceOwner> ITServiceOwners  { get; set; }
        public long? ITServiceManagerId { get; set; }
        public List<BusinessServiceOwner>  ITServiceManagers  { get; set; }
        public long? BusinessUnitId { get; set; }
        public List<BusinessUnitPrimaryDto> BusinessUnits  { get; set; }
        public int? RegulatoryMandateId { get; set; }
        public List<GetDynamicValueDto> RegulatoryMandates  { get; set; }
        public int? ConfidentialityId { get; set; }
        public List<GetDynamicValueDto> Confidentialitys  { get; set; }
        public int? IntegrityId { get; set; }
        public List<GetDynamicValueDto> Integritys  { get; set; }
        public int? OthersId { get; set; }
        public List<GetDynamicValueDto> Otheres  { get; set; }

        public int? AvailibilityId { get; set; }
        public List<GetDynamicValueDto> Availibilitys  { get; set; }
        public List<ITserviceBusinessServiceDto> SelectedITserviceBusinessServices  { get; set; }
        public List<long> RemoveITserviceBusinessServices  { get; set; }
        public List<ITserviceBusinessUnitDto> SelectedITserviceBusinessUnit { get; set; }
        public List<BusinessServiceSDto> BusinessServices { get; set; }
        public List<long> RemoveITserviceBusinessUnit  { get; set; }

    }


    public class ITserviceBusinessServiceDto: FullAuditedEntity<long>
    {
        public long? ITServiceId { get; set; }
        public long? BusinessServiceId { get; set; }
    }

    public class ITserviceBusinessUnitDto : FullAuditedEntity<long>
    {
        public long? ITServiceId { get; set; }

        public long? BusinessUnitId { get; set; }
    }


}
