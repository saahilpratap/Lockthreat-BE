using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessEntities;
using Lockthreat.Employees;
using Lockthreat.OrganizationSetups;
using Lockthreat.RiskManagements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessImpactAnalysis_BIA_
{
  public   class BusinessImpactAnalysis : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }
        public string BIAId { get; set; }
        public long? LockThreatOrganizationId  { get; set; }
        public LockThreatOrganization LockThreatOrganization  { get; set; }
        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public string BIATitle { get; set; }

        public long? BIAOwnerId { get; set; }
        public Employee BIAOwner { get; set; }

        public string Description { get; set; }

        public long? BIAManagerId { get; set; }
        public Employee BIAManager { get; set; }

        public int? RiskCategoryId { get; set; }
        public DynamicParameterValue RiskCategory { get; set; }

        public DateTime? NextReviewDate { get; set; }

        
        public Criticality  Criticality { get; set; }

        public int? BIATypeId { get; set; }
        public DynamicParameterValue BIAType { get; set; }

        public int? RiskLikelihoodId { get; set; }
        public DynamicParameterValue RiskLikelihood { get; set; }

        public DateTime? NextEvaluation { get; set; }

        public int? RiskImpactId  { get; set; }
        public DynamicParameterValue RiskImpact { get; set; }

        public int? PersistenceId  { get; set; }
        public DynamicParameterValue Persistence { get; set; }

        public int? EvaluationFrequency { get; set; }

        public DateTime? EvaluationIRR { get; set; }

        public int? VelocityId  { get; set; }
        public DynamicParameterValue Velocity { get; set; }

        public int? DurationId  { get; set; }
        public DynamicParameterValue Duration { get; set; }

        public int? ResidualRiskId  { get; set; }
        public DynamicParameterValue ResidualRisk  { get; set; }

       public int?  ExpectedLoss { get; set; }

        public int? InherentRiskId  { get; set; }
        public DynamicParameterValue InherentRisk { get; set; }

        public int? RiskTreatmentSelectedId  { get; set; }
        public DynamicParameterValue RiskTreatmentSelected  { get; set; }

        

    }
}
