using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.OrganizationSetup.Dto
{
  public  class GetOrganizationDto  
    {
        public long Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyId  { get; set; }
    }
}
