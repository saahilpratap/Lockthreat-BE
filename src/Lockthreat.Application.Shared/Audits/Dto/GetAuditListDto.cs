using Abp.Application.Services.Dto;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Findings.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Audits.Dto
{
 public  class GetAuditListDto : EntityDto<long>
    {
        public int? TenantId { get; set; }

        public string AuditId { get; set; }

        public string AuditTitle { get; set; }

        public AuditType AuditTypes { get; set; }

        public string AuditTypeseother { get; set; }

        public int? FinacialYearId { get; set; }
        public DynamicParameterValue FinacialYear { get; set; }

        public string FinacialYearOther { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int? AuditDuration { get; set; }

        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; }

        public string AuditLocationAddressOne { get; set; }

        public string AuditLocationAddressTwo { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }

        public int? AuditAreaId { get; set; }
        public DynamicParameterValue AuditArea { get; set; }

        public string AuditReference { get; set; }


        public long? LeadAuditorId { get; set; }
        public BusinessServiceOwner  LeadAuditor { get; set; }

        public long? AuditContactId { get; set; }
        public BusinessServiceOwner  AuditContact { get; set; }

        public long? VendorId { get; set; }
        public VendorListDto Vendor { get; set; }

        public int? BudgetedHours { get; set; }

        public long? ProjectNameId { get; set; } 

        public ProjectListDetailsDto ProjectName { get; set; }

        public long? LockThreatOrganizationId { get; set; }
        public GetOrganizationDto  LockThreatOrganization { get; set; }


        public long? RelatedBsinessId { get; set; }
        public BusinessUnitPrimaryDto  RelatedBsiness { get; set; }

        public string AuditScope { get; set; }

        public string AuditBackground { get; set; }

        public string AuditObjectives { get; set; }

        public string AuditMemo { get; set; }

        public string DocumentChecklist { get; set; }
    }
}
