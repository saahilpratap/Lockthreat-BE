using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Audits;
using Lockthreat.BusinessProcesses;
using Lockthreat.Contacts;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.CAPA 
{
   public class CapaDetail : FullAuditedEntity<long>, IMayHaveTenant
    {
        public string CAPAId { get; set; }

        public int? TenantId { get; set; }
        public string CAPATitle { get; set; }

        public long? InternalAuditorId  { get; set; }
        public Employee InternalAuditor  { get; set; }

        public long? AuditId{ get; set; }
        public Audit Audit{ get; set; }

        public long? AuditorExternalId  { get; set; }
        public Contact AuditorExternal { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }

        public long? BusinessProcessId { get; set; }
        public BusinessProcess BusinessProcess { get; set; }

        public int? TypeId { get; set; }
        public DynamicParameterValue Type { get; set; }
        
        public string FindingorNC { get; set; }

        public string Correction { get; set; }

       public string RootCause { get; set; }

        public string FollowUpAction { get; set; }

        public DateTime? DueDate { get; set; }

        public long? AuditeeId  { get; set; }
        public Employee Auditee  { get; set; }

        public string FollowUpUpdates { get; set; }

        public bool ActionPlanAccepted { get; set; }

        public DateTime? DateAccepted { get; set; }



    }
}
