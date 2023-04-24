using Abp.Domain.Entities.Auditing;
using Lockthreat.Findings;
using Lockthreat.FindingsInformation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Incidents 
{
    [Table("IncidentFindings")]
    public class IncidentFinding : FullAuditedEntity<long>
    {
        public long? IncidentId { get; set; }
        public Incident Incident { get; set; }

        public long? FindingId { get; set; }
        public Finding Finding { get; set; }


    }
}
