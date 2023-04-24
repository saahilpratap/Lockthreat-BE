using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Abp.Organizations;
using Lockthreat.BusinessEntities;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.Organizations.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Business.Dto
{
    public class BusinessUnitListDto : EntityDto<long>, IPassivable, IHasCreationTime
    {
        public int? ParentUnit  { get; set; }
        public string BusinessUnitTitle { get; set; }
        public bool IsAuditableEntity { get; set; }
        
        public GetOrganizationForEditDto LockThreatOrganization  { get; set; }
        public int? UnitTypeId { get; set; }
        public DynamicParameterValue UnitType { get; set; }
        public bool IsActive { get; set; } 
        public DateTime CreationTime { get; set; }

        public string BusinessUnitId { get; set; }
        public long? OrganizationId { get; set; }

        public virtual long? OrganizationUnitId { get; set; }      
       public string  OraganizationUnitName   { get; set; }
       public long? EmpId { get; set; }
       public  string  EmployeeName   { get; set; }
    }


    public class ParentUnit
    {
        public long Id  { get; set; }
        public string BusinessUnitTitle { get; set; }
    }
}
