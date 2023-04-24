using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessEntities;
using Lockthreat.Findings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.FindingsInformation
{
    [Table("FindingBusinessUnits")]
    public class FindingBusinessUnit: FullAuditedEntity<long>
    {

        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }

        public long? FindingId { get; set; }
        public Finding Finding { get; set; }

    }
}
