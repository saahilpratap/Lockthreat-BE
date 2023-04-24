using Abp.DynamicEntityParameters;
using Lockthreat.Employee.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.BusinessProcesses.Dto
{
    public class GetBusinessProcessForEditDto
    {
        public int? Id { get; set; }
        public int? TenantId { get; set; } 
        public string BusinessProcessId { get; set; } 
        [Required]
        public string BusinessProcessName { get; set; } 
        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; } 
        public string Description { get; set; } 
        public int? ProcessTypeId { get; set; }
        public DynamicParameterValue ProcessType { get; set; } 
        public int? SLAApplicableId { get; set; }
        public DynamicParameterValue SLAApplicable { get; set; } 
        public int? ActivityCycleId { get; set; }
        public DynamicParameterValue ActivityCycle { get; set; } 
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; } 
        public string PostalCode { get; set; }
        public int? CountryId { get; set; }
        public DynamicParameterValue Country { get; set; }
        public long? CompanyNameId { get; set; }
        public GetOrganizationForEditDto CompanyName { get; set; } 
        public long? ProcessManagerId { get; set; }
        public GetEmployeeForEditDto ProcessManager { get; set; } 
        public long? ProcessOwnerId { get; set; }
        public GetEmployeeForEditDto ProcessOwner { get; set; } 
        public long? BusinessUnitOwnerId { get; set; }
        public GetEmployeeForEditDto BusinessUnitOwner { get; set; } 
        public int? RegulatoryMandateId { get; set; }
        public DynamicParameterValue RegulatoryMandate { get; set; } 
        public int? ProcessPriorityId { get; set; }
        public DynamicParameterValue ProcessPriority { get; set; } 
        public int? OthersId { get; set; }
        public DynamicParameterValue Others { get; set; } 
        public int? ConfidentialityId { get; set; }
        public DynamicParameterValue Confidentiality { get; set; } 
        public int? ReviewPeriodId { get; set; }
        public DynamicParameterValue ReviewPeriod { get; set; } 
        public int? IntergrityId { get; set; }
        public DynamicParameterValue Intergrity { get; set; } 
        public int? AvailibilityId { get; set; }
        public DynamicParameterValue Availibility { get; set; } 
        public string Documents { get; set; }
    }
}
