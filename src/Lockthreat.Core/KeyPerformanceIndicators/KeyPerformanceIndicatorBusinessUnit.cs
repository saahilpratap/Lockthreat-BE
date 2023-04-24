using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.KeyPerformanceIndicators
{
   public class KeyPerformanceIndicatorBusinessUnit : FullAuditedEntity<long>
    {
        public long? KeyPerformanceIndicatorId  { get; set; }
        public KeyPerformanceIndicator KeyPerformanceIndicator { get; set; }

        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }


    }
}
