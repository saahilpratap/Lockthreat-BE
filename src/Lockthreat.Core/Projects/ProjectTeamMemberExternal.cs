using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Projects 
{
  public  class ProjectTeamMemberExternal : FullAuditedEntity<long>
    {
        public long? ProjectId  { get; set; }
        public Project Project  { get; set; }

        public long? TeamMembersExternalId { get; set; }
        public Employee TeamMembersExternal { get; set; }
    }
}
