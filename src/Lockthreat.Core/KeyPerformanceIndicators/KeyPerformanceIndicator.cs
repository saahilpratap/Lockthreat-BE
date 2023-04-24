using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.KeyPerformanceIndicators
{
  public  class KeyPerformanceIndicator  : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string KeyPerformanceIndicatorId { get; set; }

        [Required]
        public string KeyPerformanceIndicatorTitle { get; set; }

        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; }

        public int? FrequencyId { get; set; }
        public DynamicParameterValue Frequency  { get; set; }

        public string Description { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization { get; set; }

        public ICollection<KeyPerformanceIndicatorAdministrator> SelectedAdministrators  { get; set; }

        public ICollection<KeyPerformanceIndicatorBusinessUnit> SelectedBusinessUnits  { get; set; }

    }
}
