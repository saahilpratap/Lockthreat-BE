using Abp.Domain.Entities.Auditing;
using Lockthreat.RiskTreatments;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contracts
{
 public   class ContractRiskTreatment  : FullAuditedEntity<long>
    {
        public long? ContractsId { get; set; } 
        public Contract Contract  { get; set; }
        public long? RiskTreatmentId  { get; set; }
        public RiskTreatment RiskTreatment  { get; set; }

        

    }
}
