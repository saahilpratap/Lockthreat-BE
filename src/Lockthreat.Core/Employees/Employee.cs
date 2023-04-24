using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Authorization.Users;
using Lockthreat.BusinessEntities;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Employees 
{
    [Table("Employees")]
    public class Employee : FullAuditedEntity<long>, IMayHaveTenant
    {

        public int? TenantId { get; set; }

        public string EmployeeId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string CellPhone { get; set; }
        public string DirectPhone { get; set; }

        public int? Age { get; set; }

        public string ProfilePicture { get; set; } //stores Base 64 string

        public bool IsNotifiedByEmail { get; set; }

        public int? EmployeeGradeId  { get; set; }
        public DynamicParameterValue EmployeeGrade { get; set; }

        public int? EmployeeTypeId { get; set; }
        public DynamicParameterValue EmployeeType { get; set; }
       
        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }

        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }

       
        public string EmployeePosition { get; set; }
        public long? UserId { get; set; }
        public User User { get; set; }

        public string AccessCardId { get; set; }

        public string CompanyId { get; set; }

        public int? RiskGroupId  { get; set; }
        public DynamicParameterValue RiskGroup  { get; set; }

        //...BusinessServiceOwner and BusinessServiceManager,userlink,riskgroup is Remaining


    }
}
