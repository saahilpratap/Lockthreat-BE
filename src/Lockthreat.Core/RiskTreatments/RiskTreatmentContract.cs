using Abp.Domain.Entities.Auditing;
using Lockthreat.Contracts;
using System;
using System.Collections.Generic;

using System.Text;

namespace Lockthreat.RiskTreatments 
{
  public  class RiskTreatmentContract : FullAuditedEntity<long>
    {
        public long? RiskTreatmentId  { get; set; }
        public RiskTreatment RiskTreatment  { get; set; }

        public long? ContractId  { get; set; }

        public Contract Contract { get; set; }

    }
}
