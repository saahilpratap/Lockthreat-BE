using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessProcesses.Dto;
using Lockthreat.BusinessServices.Dto;
using Lockthreat.Contacts.Dto;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.FacilitieDatacenters;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contracts.Dto
{
   public class ContractDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }
        public string ContractId { get; set; }      
        public string ContractTitle { get; set; }
        public string ContractReference { get; set; }
        public string Description { get; set; }
        public int? ContractValue { get; set; }
        public int? ContractTypeId { get; set; }
        public List<GetDynamicValueDto> ContractTypes  { get; set; }
        public int? ContractCategoryId { get; set; }
        public List<GetDynamicValueDto> ContractCategorys  { get; set; }
        public long? VendorId { get; set; }
        public List<VendorsDto> Vendors { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; } 
        public long? EmployeeId { get; set; }
        public List<BusinessServiceOwner> EmployeesList { get; set; }
        public List<ITserviceListDto> ITserviceLists { get; set; }
        public List<BusinessServiceSDto> BusinessServices { get; set; }
        public List<BusinessProcessDetailDto> BusinessProcess { get; set; }
        public List<ContractBusinessProcessDto> SelectedContractBusinessProcess { get; set; }
        public List<ContractBusinessServiceDto> SelectedContractBusinessService { get; set; }
        public List<ContractEmployeeDto> SelectedContractEmployee { get; set; }
        public List<ContractEmployeeNotificationDto> SelectedContractEmployeeNotification { get; set; }
        public List<ContractITServiceDto> SelectedContractITService { get; set; }
        public List<ContractRiskTreatmentDto> SelectedContractRiskTreatment { get; set; }

    }

    public class ContractBusinessProcessDto 
    {
        public long Id { get; set; }
        public long? ContractId { get; set; }
        public long? BusinessProcessId { get; set; }
    }

    public class ContractBusinessServiceDto
    {
        public long Id { get; set; }
        public long? ContractId { get; set; }
        public long? BusinessServiceId { get; set; } 
    }

    public class ContractEmployeeDto
    {
        public long Id { get; set; }
        public long? ContractId { get; set; }
        public long? EmployeeId { get; set; }
    }

    public class ContractEmployeeNotificationDto
    {
        public long Id { get; set; }
        public long? ContractId { get; set; }
        public long? EmployeeId { get; set; }
    }

    public class ContractITServiceDto
    {
        public long Id { get; set; }
        public long? ContractId { get; set; }
        public long? ITServiceId { get; set; }
    }

    public class ContractRiskTreatmentDto
    {
        public long Id { get; set; }
        public long? ContractId { get; set; }
        public long? RiskTreatmentId { get; set; }
    }
}
