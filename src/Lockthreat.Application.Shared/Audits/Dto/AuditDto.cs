using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.Findings.Dto;
using Lockthreat.HardwareAssets.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.SystemApplications.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Audits.Dto
{
   public  class AuditDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string AuditId { get; set; }
        public string AuditTitle { get; set; }
        public AuditType AuditTypes { get; set; }
        public string AuditTypeseother { get; set; }
        public int? FinacialYearId { get; set; }
        public List<GetDynamicValueDto> FinacialYearList  { get; set; }
        public string FinacialYearOther { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? AuditDuration { get; set; }
        public int? StatusId { get; set; }
        public List<GetDynamicValueDto> StatusList  { get; set; }
        public string AuditLocationAddressOne { get; set; }

        public string AuditLocationAddressTwo { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int? CountryId { get; set; }
        public List<CountryDto> Countries { get; set; }
        public int? AuditAreaId { get; set; }
        public List<GetDynamicValueDto> AuditAreaList  { get; set; }
        public string AuditReference { get; set; }
        public long? LeadAuditorId { get; set; }
        public List<BusinessServiceOwner> LeadAuditorList  { get; set; }
        public long? AuditContactId { get; set; }
        public List<BusinessServiceOwner> AuditContactList  { get; set; }
        public long? VendorId { get; set; }
        public List<VendorListDto> VendorList  { get; set; }
        public int? BudgetedHours { get; set; }
        public long? ProjectNameId { get; set; }
        public List<ProjectListDetailsDto> ProjectList  { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> LockThreatOrganizationList  { get; set; }
        public long? RelatedBsinessId { get; set; }
        public List<BusinessUnitPrimaryDto> RelatedBsinessList  { get; set; }
        public string AuditScope { get; set; }
        public string AuditBackground { get; set; }
        public string AuditObjectives { get; set; }
        public string AuditMemo { get; set; }
        public string DocumentChecklist { get; set; }
        public List<BusinessServiceSDto> BusinessServices { get; set; }
        public List<BusinessProcessDetailDto> BusinessProcess { get; set; }
        public List<FacilitieDatacenterListDto> FacilitiesDatacenterList { get; set; }
        public List<FindingDetailsDto> FindingList { get; set; }
        public List<SytemApplicationDto> SystemAplicationList  { get; set; }
        public List<AuditAuditorDto> SelectedAuditAuditors   { get; set; }
        public List<AuditBusinessProcessDto> SelectedAuditBusinessProcess  { get; set; }
        public List<AuditBusinessServiceDto> SelectedAuditBusinessServices  { get; set; }
        public List<AuditFacilitieDatacenterDto> SelectedAuditFacilitieDatacenters  { get; set; }
        public List<AuditTeamDto> SelectedAuditTeams  { get; set; }
        public List<AuditVendorDto> SelectedAuditVendors  { get; set; }
        public List<AuditAttachmentDto> SelectedAuditAttachments { get; set; }
        public List<AuditFindingDto> SelectedAuditFindings { get; set; }
        public List<AuditSystemApplicationDto> SelectedAuditSystemApplications  { get; set; }
        public List<long> RemovedAuditSystemApplications { get; set; }
        public List<long> RemovedAuditAuditors  { get; set; }
        public List<long> RemovedAuditBusinessProcess  { get; set; }
        public List<long> RemovedAuditBusinessServices  { get; set; }
        public List<long> RemovedAuditFacilitieDatacenters  { get; set; }
        public List<long> RemovedAuditTeams  { get; set; }
        public List<long> RemovedAuditVendors { get; set; }
        public List<long> RemovedAuditAttachments  { get; set; }
        public List<long> RemovedAuditFindings  { get; set; }
    }
    public class AuditFindingDto
    {
        public long Id { get; set; }
        public long? AuditId { get; set; }

        public long? FindingId { get; set; }
    }
    public class AuditAttachmentDto
    {
        public long Id { get; set; }
        public long? AuditId { get; set; }     
        public string Documents { get; set; }
    }
    public class AuditAuditorDto
    {
        public long Id { get; set; }
        public long? AuditId { get; set; }
        public long? EmployeeId { get; set; }
    }
    public class AuditBusinessProcessDto
    {
        public long Id { get; set; }
        public long? AuditId { get; set; }
        public long? BusinessProcessId { get; set; }
    }
    public class AuditBusinessServiceDto
    {
        public long Id { get; set; }
        public long? AuditId { get; set; }
        public long? BusinessServiceId { get; set; }
    }
    public class AuditFacilitieDatacenterDto
    {
        public long Id { get; set; }
        public long? AuditId { get; set; }
        public long? FacilitieDatacenterId { get; set; }
    }
    public class AuditTeamDto
    {
        public long Id { get; set; }
        public long? AuditId { get; set; }
        public long? EmployeeId { get; set; }
    }
    public class AuditVendorDto
    {
        public long Id { get; set; }
        public long? AuditId { get; set; }

        public long? VendorId { get; set; }
    }
    public class ProjectListDetailsDto
    {
        public long Id { get; set; }
        public string ProjectName { get; set; }
    }
    public class AuditSystemApplicationDto
    {
        public long Id { get; set; }
        public long? AuditId { get; set; }
        public long? SystemApplicationId { get; set; }
    }
    public class FindingDetailsDto
    {
        public long Id { get; set; }
        public string FindingTitle { get; set; }
    }


}
