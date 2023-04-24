using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.ITServices
{
    [Table("ITServiceBusinessServices")]
    public class ITServiceBusinessService: FullAuditedEntity<long>
    {
        public long? ITServiceId  { get; set; }
        public ITService ITService { get; set; }
        public long? BusinessServiceId  { get; set; }
        public BusinessService BusinessService { get; set; }
    }
}
