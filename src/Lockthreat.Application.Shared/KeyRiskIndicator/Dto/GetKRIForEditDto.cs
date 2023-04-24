using Abp.DynamicEntityParameters;
using Lockthreat.Business.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.KeyRiskIndicator.Dto
{
    public class GetKRIForEditDto
    {
        public long? Id { get; set; }
        public int? TenantId { get; set; } 
        public string KeyRiskIndicatorsId { get; set; } 
        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; }
        [Required]
        public string KeyRiskIndicatorTitle { get; set; } 
        public string Description { get; set; } 
        public long? CompanyNameId { get; set; }
        public GetOrganizationForEditDto CompanyName { get; set; } 
    }
}
