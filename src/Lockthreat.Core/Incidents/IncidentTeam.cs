using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Incidents 
{
  public  class IncidentTeam : FullAuditedEntity<long>
    {
        //public long? IncidentId { get; set; }
        //public Incident Incident { get; set; }

        public long? TeamInfoId  { get; set; }
        public Employee TeamInfo { get; set; }

    }
}
