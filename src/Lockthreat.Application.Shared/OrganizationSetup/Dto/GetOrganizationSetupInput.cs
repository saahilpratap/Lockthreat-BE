using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.OrganizationSetup.Dto
{
    public class GetOrganizationSetupInput: PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "companyName,companyId,email,phone DESC";
            }

            Filter = Filter?.Trim();
        }
    }
}
