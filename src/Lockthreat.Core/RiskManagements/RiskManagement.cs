using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessEntities;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.RiskManagements
{
 public  class RiskManagement   : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string RiskId { get; set; }

        [Required]
        public string RiskTitle { get; set; }

        public string Description { get; set; }

        public Criticality  Criticality { get; set; }

        public DateTime? LastEvaluationDate { get; set; }

        public string RiskTriggerEvent { get; set; }

        public int? RiskTypeId  { get; set; }
        public DynamicParameterValue RiskType { get; set; }

        public int? RiskCategoryId  { get; set; }
        public DynamicParameterValue RiskCategory { get; set; }

        public int? RiskSourceId  { get; set; }
        public DynamicParameterValue RiskSource  { get; set; }

        public int? RiskStateId   { get; set; }
        public DynamicParameterValue RiskState  { get; set; }

        public int? RiskStatusId  { get; set; }
        public DynamicParameterValue RiskStatus { get; set; }

        public long? CompanyNameId { get; set; }
        public LockThreatOrganization CompanyName { get; set; }
        public long? RiskOwnerId  { get; set; }
        public Employee RiskOwner  { get; set; }

        public long? RiskManagerId  { get; set; }
        public Employee RiskManager { get; set; }

        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public int? RiskScoringMethodId  { get; set; }
        public DynamicParameterValue RiskScoringMethod { get; set; }

        public DateTime? NextEvaluation { get; set; }
        public DateTime? NextEvaluationIRRBased { get; set; }

        public int? RiskLikelihoodId  { get; set; }
        public DynamicParameterValue RiskLikelihood { get; set; }

        public int? RiskImpactId  { get; set; }
        public DynamicParameterValue RiskLiRiskImpactkelihood { get; set; }
        public int? EvaluationFrequency { get; set; }
        
        public int? RiskScore { get; set; }


        public int? PersistenceId  { get; set; }
        public DynamicParameterValue Persistence { get; set; }
        public int? VelocityId  { get; set; }
        public DynamicParameterValue Velocity { get; set; }

        public int? ResidualRiskId  { get; set; }
        public DynamicParameterValue ResidualRisk  { get; set; }

        public int? InherentRiskId  { get; set; }
        public DynamicParameterValue InherentRisk { get; set; }
        public int? RiskTreatmentId  { get; set; }
        public DynamicParameterValue RiskTreatment { get; set; }

        public int? DurationId  { get; set; }
        public DynamicParameterValue Duration { get; set; }

        public int? ExpectedLoss { get; set; }




    }
}
