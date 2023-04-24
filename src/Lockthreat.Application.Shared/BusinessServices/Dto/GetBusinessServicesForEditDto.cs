using Abp.DynamicEntityParameters;
using Lockthreat.Business.Dto;
using Lockthreat.Employee.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessServices.Dto
{
    public class GetBusinessServicesForEditDto
    {
        public int? Id { get; set; }
        public int? TenantId { get; set; }
        public string BusinessServiceId { get; set; } 
        public string BusinessServiceName { get; set; } 
        public long? BusinessUnitDependentId { get; set; }
        public GetBusinessUnitForEditDto BusinessUnitDependent { get; set; } 
        public long? BusinessUnitprimaryId { get; set; }
        public GetBusinessUnitForEditDto BusinessUnitprimary { get; set; } 
        public long? CompanyNameId { get; set; }
        public GetOrganizationForEditDto CompanyName { get; set; } 
        public long? BusinessServiceOwnerId { get; set; }
        public GetEmployeeForEditDto BusinessServiceOwner { get; set; } 
        public long? BusinessServiceManagerId { get; set; }
        public GetEmployeeForEditDto BusinessServiceManager { get; set; }  
        public int? ServiceTypeId { get; set; }
        public DynamicParameterValue ServiceType { get; set; } 
        public int? ConfidentialityId { get; set; }
        public DynamicParameterValue Confidentiality { get; set; } 
        public int? IntergrityId { get; set; }
        public DynamicParameterValue Intergrity { get; set; } 
        public int? OthersId { get; set; }
        public DynamicParameterValue Others { get; set; }

        public List<BusinessUnitDto> BusinessUnits { get; set; }
    }
}
