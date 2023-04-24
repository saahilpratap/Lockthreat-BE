using Abp.DynamicEntityParameters;
using Lockthreat.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Business.Dto
{
    public class CreateOrUpdateBusinessUnitInput
    {
        public long? Id { get; set; }
        public int? TenantId { get; set; }
        public string BusinessUnitId { get; set; }
        public long? LockThreatOrganizationId   { get; set; }
        public string BusinessUnitTitle { get; set; }
        public bool IsAuditableEntity { get; set; }
        public int? UnitTypeId { get; set; }

       // public DynamicParameterValue UnitType { get; set; }
      //  public UnitType UnitType { get; set; }
        public int? ParentUnit { get; set; }
        public virtual long? OrganizationUnitId { get; set; }
        public long? EmpId { get; set; }
    }
}
