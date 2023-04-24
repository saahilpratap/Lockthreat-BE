using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessProcesses.Dto
{
    public class GetBusinessProcessInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public long? OrganizationId { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "businessProcessName,businessProcessId DESC";
            }

            Filter = Filter?.Trim();
        }
    }
}
