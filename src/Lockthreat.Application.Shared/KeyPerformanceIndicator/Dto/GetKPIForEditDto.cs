using Abp.DynamicEntityParameters;
using Lockthreat.Employee.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.KeyPerformanceIndicator.Dto
{
    public class GetKPIForEditDto
    {
        public long? Id { get; set; }
        public int? TenantId { get; set; } 
        public string KeyPerformanceIndicatorId { get; set; } 
        public string KeyPerformanceIndicatorTitle { get; set; } 
        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; } 
        public int? FrequencyId { get; set; }
        public DynamicParameterValue Frequency { get; set; } 
        public string Description { get; set; } 
        public long? KeyPerformanceIndicatorOwnerId { get; set; }
        public GetEmployeeForEditDto KeyPerformanceIndicatorOwner { get; set; } 
        public long? CompanyNameId { get; set; }
        public GetOrganizationForEditDto CompanyName { get; set; }
    }
}
