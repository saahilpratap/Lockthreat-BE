using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocument.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Countries.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessProcesses.Dto
{
 public  class BusinessProcessDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string BusinessProcessId { get; set; }    
        public string BusinessProcessName { get; set; }
        public int? StatusId { get; set; }
        public List<GetDynamicValueDto> Statuses  { get; set; }
        public string Description { get; set; }
        public int? ProcessTypeId { get; set; }
        public List<GetDynamicValueDto> ProcessTypes { get; set; }
        public int? SlaApplicableId { get; set; }
        public List<GetDynamicValueDto> SlaApplicables  { get; set; }
        public int? ActivityCycleId { get; set; }
        public List<GetDynamicValueDto> ActivityCycles  { get; set; }
        public List<AuthoratativeDocumentsDto> AuthoratativeDocuments { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public int? CountryId { get; set; }
        public List<CountryDto> Countries { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; } 
        public long? ProcessManagerId { get; set; }
        public List<BusinessServiceOwner> ProcessManagers  { get; set; }       
        public long? ProcessOwnerId { get; set; }
        public List<BusinessServiceOwner>  ProcessOwners  { get; set; }
        public long? BusinessUnitId { get; set; }
        public List<BusinessUnitPrimaryDto> BusinessUnits { get; set; }
        public int? RegulatoryId { get; set; }
        public List<GetDynamicValueDto> Regulatorys  { get; set; }
        public int? ProcessPriorityId { get; set; }
        public List<GetDynamicValueDto> ProcessPrioritys  { get; set; }     
        public int? OthersId { get; set; }
        public List<GetDynamicValueDto> Otheres  { get; set; }
        public int? ConfidentialityId { get; set; }
        public List<GetDynamicValueDto> Confidentialitys  { get; set; }
        public int? ReviewPeriodId { get; set; }
        public List<GetDynamicValueDto> ReviewPeriods  { get; set; }
        public int? IntergrityId { get; set; }
        public List<GetDynamicValueDto> Intergritys  { get; set; }
        public int? AvailibilityId { get; set; }
        public List<GetDynamicValueDto> Availibilityes   { get; set; }
        public string Documents { get; set; }
        public List<BusinessServiceSDto> BusinessServices { get; set; }
        public List<BusinessProcessAuthorativeDocumentDto> SelectedBusinessProcessAuthorativeDocuments  { get; set; }
        public List<long> RemovedBusinessProcessAuthorativeDocuments { get; set; }
        public List<BusinessProcessUnitDto> SelectedBusinessProcessUnits  { get; set; }
        public List<long> RemovedBusinessProcessUnits  { get; set; }
        public List<BusinessProcessServiceDto> SelectedBusinessProcessServices  { get; set; }
        public List<long> RemovedBusinessProcessServices  { get; set; }

    }

    public class BusinessProcessAuthorativeDocumentDto: FullAuditedEntity<long>
    {
        public long? BusinessProcessId { get; set; }

        public long? AuthoratativeDocumentId { get; set; }
    }

    public class BusinessProcessUnitDto  : FullAuditedEntity<long>
    {
        public long? BusinessProcessId { get; set; }

        public long? BusinessUnitId { get; set; }

    }


    public class BusinessProcessServiceDto: FullAuditedEntity<long>
    {
        public long? BusinessProcessId { get; set; }

        public long? BusinessServiceId { get; set; }
    }

    public class BusinessServiceSDto 
    {
        public long? Id { get; set; }
        public string BusinessServiceName { get; set; }
    }

}
