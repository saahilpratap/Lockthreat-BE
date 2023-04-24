using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.Incidents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Findings 
{

 public  class FindingIncident  : FullAuditedEntity<long>
    {
        public long? FindingId  { get; set; }
        public Finding Finding  { get; set; }

        public long? IncidentId { get; set; }
        public Incident Incident { get; set; }

    }
}
