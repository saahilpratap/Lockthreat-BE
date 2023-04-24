using Abp.Domain.Entities.Auditing;
using Lockthreat.Audits;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Projects 
{
  public  class ProjectAudit  : FullAuditedEntity<long>
    {
        public long? ProjectId  { get; set; }
        public Project Project  { get; set; }
        public long? AuditId { get; set; }
        public Audit  Audit { get; set; }
    }
}
