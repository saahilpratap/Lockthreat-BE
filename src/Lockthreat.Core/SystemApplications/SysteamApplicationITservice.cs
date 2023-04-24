using Abp.Domain.Entities.Auditing;
using Lockthreat.ITServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.SystemApplications
{
 public   class SysteamApplicationITservice: FullAuditedEntity<long>
    {

        public long? SystemApplicationId { get; set; }
        public SystemApplication SystemApplication { get; set; }

        public long? ITServiceId  { get; set; }
        public ITService ITService { get; set; }



    }
}
