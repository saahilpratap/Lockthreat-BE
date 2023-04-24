using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Projects 
{
  public  class ProjectTeamMember : FullAuditedEntity<long>
    {
        public long? ProjectId  { get; set; }
        public Project Project  { get; set; }

        public long? TeamMembersInternalId  { get; set; }
        public Employee TeamMembersInternal  { get; set; }

        
    }
}
