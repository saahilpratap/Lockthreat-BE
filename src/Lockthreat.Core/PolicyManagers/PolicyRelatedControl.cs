using Abp.Domain.Entities.Auditing;
using Lockthreat.Citations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.PolicyManagers
{
  public  class PolicyRelatedControl : FullAuditedEntity<long>
    {
        public long? PolicyManagerId { get; set; }
        public PolicyManager PolicyManager { get; set; }

        public long? CitationId { get; set; }
        public Citation Citation  { get; set; }
        
    }
}
