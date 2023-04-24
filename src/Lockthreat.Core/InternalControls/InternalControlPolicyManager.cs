using Abp.Domain.Entities.Auditing;
using Lockthreat.PolicyManagers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.InternalControls
{
  public  class InternalControlPolicyManager : FullAuditedEntity<long>
    {
        public long? InternalControlId { get; set; }

        public InternalControl InternalControl { get; set; }

        public long? PolicyManagerId { get; set; }
        public PolicyManager PolicyManager { get; set; }

    }
}
