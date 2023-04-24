using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.KeyPerformanceIndicator.Dto
{
    public class GetKeyPerformanceIndicatorInput:PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public long? OrganizationId { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "keyPerformanceIndicatorTitle,keyPerformanceIndicatorId,description DESC";
            }

            Filter = Filter?.Trim();
        }
    }
}
