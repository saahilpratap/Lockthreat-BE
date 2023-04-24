using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.ITServices
{
    [Table("ITServiceBusinessUnits")]
    public  class ITServiceBusinessUnit  : FullAuditedEntity<long>
    {
        public long? ITServiceId  { get; set; }

        public ITService ITService  { get; set; }

        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }

    }
}
