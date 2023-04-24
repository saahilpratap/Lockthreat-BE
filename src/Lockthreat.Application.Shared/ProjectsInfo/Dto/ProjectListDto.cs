using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ProjectsInfo.Dto
{
    public class ProjectListDto
    {
        public long Id { get; set; }

        public string ProjectId { get; set; }

        public string ProjectName { get; set; }

        public string SponserName { get; set; }

        public string SponserPosition { get; set; }

        public string SponserCompany { get; set; }


        public string DirectorName { get; set; }

        public string DirectorPosition { get; set; }

        public string DirectorCompany { get; set; }

        public string LockThreatOrganization  { get; set; }

        public string ParentProgramName { get; set; }
    }
}
