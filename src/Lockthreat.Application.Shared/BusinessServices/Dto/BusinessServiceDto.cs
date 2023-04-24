using Abp.Domain.Entities.Auditing;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.ITservices.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessServices.Dto
{
        public class BusinessServiceDto : FullAuditedEntity<long>
        {
            public int? TenantId { get; set; }
            public string BusinessServiceId { get; set; }
            public string BusinessServiceName { get; set; }
            public long? BusinessUnitDependentId { get; set; }
            public List<BusinessUnitPrimaryDto> BusinessUnits { get; set; }
            public long? BusinessUnitprimaryId { get; set; }
            public long? LockThreatOrganizationId { get; set; }
            public List<GetOrganizationDto> CompanyLists { get; set; }
            public long? BusinessServiceOwnerId { get; set; }
            public List<BusinessServiceOwner> BusinessServiceOwners { get; set; }
            public long? BusinessServiceManagerId { get; set; }
            public int? ServiceTypeId { get; set; }
            public List<GetDynamicValueDto> ServiceTypes { get; set; }
            public int? ConfidentialityId { get; set; }
            public List<GetDynamicValueDto> Confidentialitys { get; set; }
            public int? IntergrityId { get; set; }
            public List<GetDynamicValueDto> Intergritys { get; set; }
            public int? OthersId { get; set; }
            public List<GetDynamicValueDto> Otheres { get; set; }
            public int? AvailibilityId { get; set; }
            public List<GetDynamicValueDto> Availibilitys { get; set; }
            public List<ITserviceListDto> ITserviceLists { get; set; }
            public List<ITserviceBusinessServiceDto> SelectedItServices { get; set; }
            public List<long> RemovedItServices { get; set; }
            public List<long> RemovedBusinessUnits { get; set; }
            public List<ServiceBusinessUnitDto> SelectdBusinessUnits { get; set; }
        }
        public class BusinessServiceOwner
        {
            public long Id { get; set; }

            public string EmployeeName { get; set; }

            public long OrganizationId { get; set; }
        }
        public class ServiceBusinessUnitDto
        {
            public long Id { get; set; }
            public long? BusinessServiceId { get; set; }
            public long? BusinessUnitId { get; set; }
        }
        public class ItServicesDto
        {
            public long Id { get; set; }
            public long? BusinessProcessId { get; set; }
            public long? ITServiceId { get; set; }

        }
        public class ITserviceListDto
        {
               public long Id { get; set; }
               public string ITServicesId { get; set; }
               public string ITServiceName { get; set; }
        }
        public class BusinessUnitPrimaryDto 
        {
         public long Id { get; set; }
         public string BusinessUnitTitle { get; set; }
         public long?  LockThreatOrganizationId { get; set; }
        }

       public class   BusinessUnitGaurdianDto 
       {
        public long Id { get; set; }
        public string BusinessUnitTitle { get; set; }
        public long? LockThreatOrganizationId { get; set; }
       }
}
