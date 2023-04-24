using Abp.Domain.Entities.Auditing;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.AuthoratativeDocuments
{
    [Table("AuthoratativeDocumentOrganization")]
    public class AuthoratativeDocumentOrganization : FullAuditedEntity<long>
    {
        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization { get; set; }

        public long? AuthoratativeDocumentId { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }


        
    }
}
