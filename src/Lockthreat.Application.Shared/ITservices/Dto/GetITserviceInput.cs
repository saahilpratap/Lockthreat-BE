using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ITservices.Dto
{
 public   class GetITserviceInput : PagedAndSortedInputDto, IShouldNormalize
    {

        public string Filter { get; set; }

        public long? OrganizationId { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "iTServiceName,iTServicesId DESC";
            }

            Filter = Filter?.Trim();
        }
    }
}
