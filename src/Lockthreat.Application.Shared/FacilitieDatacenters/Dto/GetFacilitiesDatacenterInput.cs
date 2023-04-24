using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.FacilitieDatacenters.Dto
{
  public  class GetFacilitiesDatacenterInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public long? OrganizationId { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "facilityName,facilityId DESC";
            }

            Filter = Filter?.Trim();
        }
    }
}
