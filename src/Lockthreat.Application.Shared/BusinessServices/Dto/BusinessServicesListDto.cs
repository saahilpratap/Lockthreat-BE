using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employee.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessServices.Dto
{
    public class BusinessServicesListDto : EntityDto<long>, IPassivable, IHasCreationTime
    {
        public string BusinessServiceId { get; set; } 
        public string BusinessServiceName { get; set; }
        public bool IsActive { get; set; }      
        public DateTime CreationTime { get; set; }
        public long? BusinessServiceOwnerId { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public GetOrganizationDto LockThreatOrganization { get; set; }
        public GetEmployeeForEditDto BusinessServiceOwner { get; set; } 
        public long? BusinessServiceManagerId { get; set; }
        public GetEmployeeForEditDto BusinessServiceManager { get; set; }

        public long? BusinessUnitDependentId { get; set; }
        public BusinessUnitPrimaryDto BusinessUnitDependent { get; set; }
        public long? BusinessUnitprimaryId { get; set; }
        public BusinessUnitPrimaryDto BusinessUnitprimary { get; set; }
        public int? ServiceTypeId { get; set; }
        public DynamicParameterValue ServiceType { get; set; } 
        public int? ConfidentialityId { get; set; }
        public DynamicParameterValue Confidentiality { get; set; } 
        public int? IntergrityId { get; set; }
        public DynamicParameterValue Intergrity { get; set; }
        public int? AvailibilityId { get; set; }
        public DynamicParameterValue Availibility { get; set; }
    }
}
