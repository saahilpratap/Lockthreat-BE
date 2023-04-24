using Abp.Domain.Entities.Auditing;
using Lockthreat.SystemApplications;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.InternalControls
{
  public  class InternalControlSystemApplication : FullAuditedEntity<long>
    {
        public long? InternalControlId { get; set; }

        public InternalControl InternalControl { get; set; }

        public long? SystemApplicationId { get; set; }
        public SystemApplication SystemApplication { get; set; }

    }
}
