using Abp.Application.Services.Dto;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Employee.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ITservices.Dto
{   
  public class GetITserviceListDto : EntityDto<long>
        {
            public string ITServicesId { get; set; }

            public string ITServiceName { get; set; }

            public int? ServiceTypeId { get; set; }
            public DynamicParameterValue ServiceType { get; set; }

            public int? ServiceClassificationId { get; set; }
            public DynamicParameterValue ServiceClassification { get; set; }

            public long? LockThreatOrganizationId { get; set; }
            public GetOrganizationDto LockThreatOrganization { get; set; }

            public long? ITServiceOwnerId { get; set; }
            public GetEmployeeForEditDto ITServiceOwner { get; set; }

            public long? BusinessUnitId { get; set; }
            public BusinessUnitPrimaryDto BusinessUnit { get; set; }

            public int? ConfidentialityId { get; set; }
            public DynamicParameterValue Confidentiality { get; set; }
            public int? IntegrityId { get; set; }
            public DynamicParameterValue Integrity { get; set; }

            public int? OthersId { get; set; }
            public DynamicParameterValue Others { get; set; }

            public int? AvailibilityId { get; set; }
            public DynamicParameterValue Availibility { get; set; }


    }
    
}
