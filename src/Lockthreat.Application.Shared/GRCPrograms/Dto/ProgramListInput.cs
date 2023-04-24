using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.GRCPrograms.Dto
{
    public class ProgramListInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }
        public bool IsLoggedInUserPrograms { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "CompanyName,ProgramId,ProgramTitle,SponserName,DirectorName";
            }

            Filter = Filter?.Trim();
        }
    }
}
