using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contracts
{
public  class ContractAttachment  : FullAuditedEntity<long>
    {
        public long? ContractId  { get; set; }
        public Contract Contract { get; set; }
        public string Document { get; set; } 
    }
}
