using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contracts
{
  public  class ContractBusinessProcess : FullAuditedEntity<long>
    {
        public long? ContractId { get; set; }
        public Contract Contract { get; set; }
        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }
    }
}
