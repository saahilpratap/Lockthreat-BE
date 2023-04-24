using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.KeyPerformanceIndicator.Dto
{
    public class KeyPerformanceIndicatorListDto : EntityDto<long>, IPassivable, IHasCreationTime
    {
        public string KeyPerformanceIndicatorId { get; set; } 
        [Required]
        public string KeyPerformanceIndicatorTitle { get; set; } 
        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; } 
        public int? FrequencyId { get; set; }
        public DynamicParameterValue Frequency { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
        public string Description { get; set; }
    }
}
