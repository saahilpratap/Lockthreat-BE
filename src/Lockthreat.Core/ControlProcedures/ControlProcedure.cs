using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessEntities;
using Lockthreat.Citations;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ControlProcedures
{
  public  class ControlProcedure : FullAuditedEntity<long>, IMayHaveTenant
    {
       public int? TenantId { get; set; }

        public string ControlProcedureId { get; set; }

        public string ProcedureName { get; set; }

        public int? ControlProcedureTypeId  { get; set; }
        public DynamicParameterValue ControlProcedureType { get; set; }

        public int? OperationalFrequencyId  { get; set; }
        public DynamicParameterValue OperationalFrequency { get; set; }

        public int? ActivityCycleId  { get; set; }
        public DynamicParameterValue ActivityCycle  { get; set; }

        public string Description { get; set; }

        public int? ProcedureCategoryId  { get; set; }
        public DynamicParameterValue ProcedureCategory  { get; set; }

        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }

        public long? ProcedureManagerId  { get; set; }
        public Employee ProcedureManager { get; set; }

        public long? ProcedureOwnerId  { get; set; }
        public Employee ProcedureOwner { get; set; }

        public int? TestTypeId  { get; set; }
        public DynamicParameterValue TestType  { get; set; }

        public long? TesterId  { get; set; }
        public Employee Tester { get; set; }

        public long? CitationId  { get; set; }
        public Citation Citation { get; set; }



        

        


    }
}
