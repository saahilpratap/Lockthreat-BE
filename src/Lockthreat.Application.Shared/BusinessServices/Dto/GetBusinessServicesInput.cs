using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessServices.Dto
{
    public class GetBusinessServicesInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public long? OrganizationId { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "businessServiceId,businessServiceName DESC";
            }

            Filter = Filter?.Trim();
        }
    }
}
