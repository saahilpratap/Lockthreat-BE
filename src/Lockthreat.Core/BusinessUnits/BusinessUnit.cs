using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Abp.Organizations;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.BusinessEntities
{
    [Table("BusinessUnits")]
    public class BusinessUnit : FullAuditedEntity<long>, IMayHaveTenant,IMayHaveOrganizationUnit
    {

        public int? TenantId { get; set; }

        public string BusinessUnitId { get; set; }

        public long? LockThreatOrganizationId  { get; set; }
        public  LockThreatOrganization LockThreatOrganization { get;set;}

        public string BusinessUnitTitle { get; set; }
        public bool IsAuditableEntity { get; set; }

        public int? UnitTypeId  { get; set; }
        public DynamicParameterValue UnitType  { get; set; }

        public int? ParentUnit { get; set; }

       
        public virtual long? OrganizationUnitId { get; set; }

        public  long? EmpId  { get; set; }

        //....Need to add EntityHeader
    }
}
