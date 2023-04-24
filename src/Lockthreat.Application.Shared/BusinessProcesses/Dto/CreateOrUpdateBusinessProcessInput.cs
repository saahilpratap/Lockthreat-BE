using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.BusinessProcesses.Dto
{
    public class CreateOrUpdateBusinessProcessInput
    {
        public long? Id { get; set; }
        public int? TenantId { get; set; }

        public string BusinessProcessId { get; set; }
      
        public string BusinessProcessName { get; set; } 
        public int? StatusId { get; set; } 
        public string Description { get; set; } 
        public int? ProcessTypeId { get; set; } 
        public int? SLAApplicableId { get; set; } 
        public int? ActivityCycleId { get; set; } 
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; } 
        public string PostalCode { get; set; }
        public int? CountryId { get; set; } 
        public long? CompanyNameId { get; set; } 
        public long? ProcessManagerId { get; set; } 
        public long? ProcessOwnerId { get; set; } 
        public long? BusinessUnitOwnerId { get; set; } 
        public int? RegulatoryMandateId { get; set; } 
        public int? ProcessPriorityId { get; set; } 
        public int? OthersId { get; set; } 
        public int? ConfidentialityId { get; set; } 
        public int? ReviewPeriodId { get; set; } 
        public int? IntergrityId { get; set; } 
        public int? AvailibilityId { get; set; } 
        public string Documents { get; set; }
    }
}
