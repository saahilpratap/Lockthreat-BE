using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.KeyRiskIndicator.Dto
{
    public class KeyRiskIndicatorListDto : EntityDto<long>, IPassivable, IHasCreationTime
    {
        public string KeyRiskIndicatorsId { get; set; } 
        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; }
       
        public string KeyRiskIndicatorTitle { get; set; } 
        public string Description { get; set; }  
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
