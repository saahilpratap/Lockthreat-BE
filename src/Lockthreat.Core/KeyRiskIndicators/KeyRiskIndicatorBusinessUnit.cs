using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.KeyRiskIndicators
{
  public  class KeyRiskIndicatorBusinessUnit: FullAuditedEntity<long>
    {
        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }

        public long? KeyRiskIndicatorId  { get; set; }
        public KeyRiskIndicator KeyRiskIndicator { get; set; }

        
    }
}
