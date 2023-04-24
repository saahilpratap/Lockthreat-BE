using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Incidents 
{
    [Table("IncidentAttachments")]
    public  class IncidentAttachment : FullAuditedEntity<long>
    {
        public long? IncidentId { get; set; }
        public Incident Incident { get; set; }

        public string Documents { get; set; }

    }
}
