using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.SystemApplications.Dto
{
 public  class GetSystemApplicationInput  : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }
        public long? OrganizationId { get; set; }      
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "systemApplicationName,systemId DESC";
            }

            Filter = Filter?.Trim();
        }
    }
}
