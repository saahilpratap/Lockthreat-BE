using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ControlStandards
{
  public  class ControlStandard : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string ControlId { get; set; }
        public string Source { get; set; }
        public string SourceVersion { get; set; }
        public string UCFCId  { get; set; }

        public string ControlName { get; set; }

        public string ControlStandardId { get; set; }

        public int? FrameworkObjectiveId   { get; set; }
        public DynamicParameterValue FrameworkObjective { get; set; }

        public int? ControlClassificationId  { get; set; }
        public DynamicParameterValue ControlClassification { get; set; }
        public int? TypeId  { get; set; }
        public DynamicParameterValue Type { get; set; }

        public int? ControlFrequencyId  { get; set; }
        public DynamicParameterValue ControlFrequency { get; set; }

        public int? FrequencyTypeId  { get; set; }
        public DynamicParameterValue FrequencyType  { get; set; }

        public int? ControlCategoryId  { get; set; }
        public DynamicParameterValue ControlCategory { get; set; }

        public int? ControlAreaId  { get; set; }
        public DynamicParameterValue ControlArea { get; set; }

       public string  ControlObjective { get; set; }

        public string ControlDescription { get; set; }

        public string ControlRequirements { get; set; }
        public string CustomApplicability { get; set; }

        public string TestingProcedure { get; set; }

        public int? SampleSize { get; set; }


    }
}
