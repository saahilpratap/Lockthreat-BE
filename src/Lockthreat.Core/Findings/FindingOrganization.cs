using Abp.Domain.Entities.Auditing;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Findings 
{
    [Table("FindingOrganizations")]
    public class FindingOrganization  : FullAuditedEntity<long>
    {
        public long? LockThreatOrganizationId { get; set; }
        public LockThreatOrganization LockThreatOrganization { get; set; }

        public long? FindingId { get; set; }
        public Finding Finding { get; set; }

    }
}
