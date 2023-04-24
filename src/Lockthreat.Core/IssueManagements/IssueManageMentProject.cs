using Abp.Domain.Entities.Auditing;
using Lockthreat.Projects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.IssueManagements
{
  public  class IssueManageMentProject  : FullAuditedEntity<long>
    {
        public long? IssueManagementId  { get; set; }
        public IssueManagement IssueManagement { get; set; }
        public long? ProjectId  { get; set; }
        public Project Project  { get; set; }
       
    }
}
