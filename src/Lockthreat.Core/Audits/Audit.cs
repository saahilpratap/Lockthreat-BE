using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Audits;
using Lockthreat.BusinessEntities;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;

using Lockthreat.Projects;
using Lockthreat.Vendors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lockthreat.Audits
{
    [Table("Audits")]
    public  class Audit : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string AuditId { get; set; }

        public string AuditTitle { get; set; }

        public AuditType AuditTypes { get; set; }

        public string  AuditTypeseother  { get; set;}

        public int? FinacialYearId { get; set; }
        public DynamicParameterValue FinacialYear { get; set; }

        public string FinacialYearOther { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate  { get; set; }

        public int? AuditDuration { get; set; }

        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; }

        public string  AuditLocationAddressOne  { get; set; }

        public string AuditLocationAddressTwo  { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }

        public int? AuditAreaId  { get; set; }
        public DynamicParameterValue AuditArea  { get; set; }

        public string AuditReference { get; set; }

        
        public long? LeadAuditorId { get; set; }
        public Employee LeadAuditor  { get; set; }

        public long? AuditContactId { get; set; }
        public Employee AuditContact  { get; set; }

        public long? VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public int? BudgetedHours { get; set; }

        public long? ProjectNameId { get; set; }

        public Project  ProjectName { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }


        public long? RelatedBsinessId { get; set; }
        public BusinessUnit RelatedBsiness { get; set; }

        public string AuditScope { get; set; }

        public string  AuditBackground { get; set; }

        public string AuditObjectives { get; set; }

        public string AuditMemo { get; set; }

        public string DocumentChecklist { get; set; }

        public ICollection<AuditAuditor> SelectedAuditAuditors { get; set; }
        public ICollection<AuditBusinessProcess> SelectedAuditBusinessProcess  { get; set; }
        public ICollection<AuditBusinessService> SelectedAuditBusinessServices { get; set; }
        public ICollection<AuditFacilitieDatacenter> SelectedAuditFacilitieDatacenters { get; set; }
        public ICollection<AuditTeam> SelectedAuditTeams { get; set; }
        public ICollection<AuditVendor> SelectedAuditVendors  { get; set; }
        public ICollection<AuditAttachment> SelectedAuditAttachments  { get; set; }
        public ICollection<AuditFinding> SelectedAuditFindings { get; set; }
        public ICollection<AuditSystemApplication> SelectedAuditSystemApplications { get; set; }

    }
}
