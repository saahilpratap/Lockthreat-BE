using Abp.Domain.Entities.Auditing;
using Lockthreat.RiskManagements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Incidents
{ 
  public  class IncidentRisk : FullAuditedEntity<long>
    {

        //public long? IncidentId  { get; set; }
        //public Incident Incident { get; set; }

        public long? RiskManagementId { get; set; }
        public RiskManagement RiskManagement { get; set; }

        
    }
}
