using Abp.Domain.Entities.Auditing;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Exceptions 
{
   public class ExceptionOrganization : FullAuditedEntity<long>
    {
        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }

        public long? ExceptionId  { get; set; }
        public Exception Exception { get; set; }
        

    }
}
