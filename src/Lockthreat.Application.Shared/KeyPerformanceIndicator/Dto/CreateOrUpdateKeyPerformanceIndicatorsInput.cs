using Abp.DynamicEntityParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.KeyPerformanceIndicator.Dto
{
    public class CreateOrUpdateKeyPerformanceIndicatorsInput
    {
        public long? Id { get; set; }
        public int? TenantId { get; set; }
        public string KeyPerformanceIndicatorId { get; set; } 
        [Required]
        public string KeyPerformanceIndicatorTitle { get; set; } 
        public int? StatusId { get; set; } 
        public int? FrequencyId { get; set; } 
        public string Description { get; set; } 
        public long? KeyPerformanceIndicatorOwnerId { get; set; } 
        public long? CompanyNameId { get; set; } 
    }
}
