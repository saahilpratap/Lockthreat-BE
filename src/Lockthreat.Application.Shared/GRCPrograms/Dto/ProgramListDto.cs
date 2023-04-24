using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.GRCPrograms.Dto
{
    public class ProgramListDto
    {
        public long Id { get; set; }

        public string SponserName { get; set; }

        public string SponserPosition { get; set; }

        public string SponserCompany { get; set; }


        public string DirectorName { get; set; }

        public string DirectorPosition { get; set; }

        public string DirectorCompany { get; set; }

        public string ProgramId { get; set; }

        public string ProgramTitle { get; set; }

        public string CompanyName { get; set; }
    }
}
