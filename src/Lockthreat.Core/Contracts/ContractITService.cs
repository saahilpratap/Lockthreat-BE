using Abp.Domain.Entities.Auditing;
using Lockthreat.ITServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contracts
{
 public  class ContractITService  : FullAuditedEntity<long>
    {
        public long? ContractId  { get; set; }

        public Contract Contract  { get; set; }

        public long? ITServiceId  { get; set; }
        public ITService ITService  { get; set; }


    }
}
