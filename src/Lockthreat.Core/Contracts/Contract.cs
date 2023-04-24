using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessProcesses;
using Lockthreat.Employees;

using Lockthreat.OrganizationSetups;
using Lockthreat.Vendors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Contracts
{
    [Table("Contracts")]
    public class Contract : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
      
        public string ContractId { get; set; }

        [Required]
        public string ContractTitle { get; set; }
        public string ContractReference { get; set; }

        public string Description { get; set; }

        public int? ContractValue { get; set; }

        public int? ContractTypeId  { get; set; }
        public DynamicParameterValue ContractType { get; set; }

        public int? ContractCategoryId  { get; set; }
        public DynamicParameterValue ContractCategory { get; set; }

        public long? VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }
        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }

        public ICollection<ContractBusinessProcess> SelectedContractBusinessProcess { get; set; }
        public ICollection<ContractBusinessService> SelectedContractBusinessService { get; set; }
        public ICollection <ContractEmployee> SelectedContractEmployee { get; set; }
        public ICollection <ContractEmployeeNotification> SelectedContractEmployeeNotification { get; set; }
        public ICollection<ContractITService> SelectedContractITService { get; set; }
        public ICollection<ContractRiskTreatment> SelectedContractRiskTreatment { get; set; }

    }
}
