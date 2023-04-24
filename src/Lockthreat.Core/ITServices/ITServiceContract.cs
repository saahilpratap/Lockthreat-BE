using Abp.Domain.Entities.Auditing;
using Lockthreat.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.ITServices
{
    [Table("ITServiceContracts")]
    public  class ITServiceContract : FullAuditedEntity<long>
    {
        public long? ITServiceId  { get; set; }
        public ITService ITService  { get; set; }

        public long? ContractId  { get; set; }
        public Contract Contract { get; set; }

    }
}
