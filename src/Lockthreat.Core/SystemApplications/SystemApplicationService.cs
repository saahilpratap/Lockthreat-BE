using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.SystemApplications
{
   public class SystemApplicationService: FullAuditedEntity<long>
    {
        public long? SystemApplicationId  { get; set; }
        public SystemApplication SystemApplication { get; set; }
        public long? BusinessServiceId { get; set; }
        public BusinessService BusinessService { get; set; }

    }
}
