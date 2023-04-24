using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.KeyRiskIndicator.Dto
{
    public class GetKeyRiskIndicatorInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public long? OrganizationId { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "keyRiskIndicatorTitle,keyRiskIndicatorsId,description DESC";
            }
            Filter = Filter?.Trim();
        }


    }
}
