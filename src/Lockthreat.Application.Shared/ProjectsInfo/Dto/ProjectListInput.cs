using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ProjectsInfo.Dto
{
    public class ProjectListInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }

        public bool IsLoggedInUserProjects { get; set; }

        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "LockThreatOrganization,ProjectId,ProjectName,SponserName,DirectorName,ParentProgramName";
            }

            Filter = Filter?.Trim();
        }
    }
}
