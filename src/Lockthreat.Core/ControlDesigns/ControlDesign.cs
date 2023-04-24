using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;

using Lockthreat.InternalControls;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ControlDesigns
{
  public  class ControlDesign : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string ControlDesignId { get; set; }

        public string Title { get; set; }

        public int? ResultStatusId  { get; set; }
        public DynamicParameterValue ResultStatus { get; set; }

        public long? InternalControlId { get; set; }
        public InternalControl InternalControl { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }
        
        public DateTime? TestEffectiveDate { get; set; }
    }
}
