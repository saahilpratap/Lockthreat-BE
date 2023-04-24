using Abp.DynamicEntityParameters;
using Abp.Runtime.Validation;
using Lockthreat.BusinessEntities;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Business.Dto
{
    public class GetBusinessUnitInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; } 
        public long? OrganizationId { get; set; }  
        
        public int? UnitType { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "businessUnitTitle,businessUnitId DESC";
            }

            Filter = Filter?.Trim();
        }

    }
}
