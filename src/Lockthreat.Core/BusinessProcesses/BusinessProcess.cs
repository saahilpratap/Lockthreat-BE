using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessEntities;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.BusinessProcesses 
{
    [Table("BusinessProcess")]
    public  class BusinessProcess : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string BusinessProcessId { get; set; }

        [Required]
        public string BusinessProcessName { get; set; }
        
        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; }

        public string Description { get; set; }
      
        public int? ProcessTypeId { get; set; }
        public DynamicParameterValue ProcessType { get; set; }

        public int? SlaApplicableId  { get; set; }
        public DynamicParameterValue SlaApplicable  { get; set; }

       
        public int? ActivityCycleId { get; set; }
        public DynamicParameterValue ActivityCycle { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public string PostalCode { get; set; }
        public int? CountryId { get; set; }
        public DynamicParameterValue Country  { get; set; }
        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }

        public long? ProcessManagerId { get; set; }
        public Employee ProcessManager  { get; set; }

        public long? ProcessOwnerId { get; set; }
        public Employee ProcessOwner  { get; set; }

        public long? BusinessUnitId  { get; set; }
        public BusinessUnit BusinessUnit  { get; set; }

        public int?  RegulatoryId  { get; set; }
        public DynamicParameterValue Regulatory  { get; set; }

        public int? ProcessPriorityId { get; set; }
        public DynamicParameterValue ProcessPriority  { get; set; }

        public int? OthersId { get; set; }
        public DynamicParameterValue Others  { get; set; }

        public int? ConfidentialityId { get; set; }
        public DynamicParameterValue Confidentiality  { get; set; }

        public int? ReviewPeriodId  { get; set; }
        public DynamicParameterValue ReviewPeriod { get; set; }

        public int? IntergrityId { get; set; }
        public DynamicParameterValue Intergrity { get; set; }

        public int? AvailibilityId { get; set; }
        public DynamicParameterValue Availibility  { get; set; }

        public string Documents { get; set; }

        public ICollection<BusinessProcessService> SelectedBusinessProcessServices  { get; set; }
        public ICollection<BusinessProcessUnit> SelectedBusinessProcessUnits  { get; set; }
        public ICollection<BusinessProcessAuthoratativeDocument> SelectedBusinessProcessAuthorativeDocuments { get; set; }

    }
}
