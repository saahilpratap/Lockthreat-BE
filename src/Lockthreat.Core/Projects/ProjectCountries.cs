using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Projects 
{
    public class ProjectCountries : FullAuditedEntity<long>
    {
        public long? ProjectId  { get; set; }
        public Project Project { get; set; }

        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }
    }
}
