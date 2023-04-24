using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contracts
{
   public class ContractBusinessService: FullAuditedEntity<long>
    {
        public long? ContractId  { get; set; }
        public Contract Contract  { get; set; }

        public long? BusinessServiceId  { get; set; }
        public BusinessService BusinessService { get; set; }

        
    }
}
