using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Incidents

{
    [Table("Incidents")]
    public class Incident: FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string IncidentId { get; set; }

        public string TechnologyId { get; set; }


        public string IncidentTitle { get; set; }

        public string Description { get; set; }

        public int? IncidentCategoryId  { get; set; }
        public DynamicParameterValue IncidentCategory { get; set; }

        public int? IncidentTypesId { get; set; }
        public DynamicParameterValue IncidentTypes  { get; set; }

        public int? IncidentPriorityId  { get; set; }
        public DynamicParameterValue IncidentPriority  { get; set; }

        public int? IncidentSeverityId  { get; set; }
        public DynamicParameterValue IncidentSeverity { get; set; }

        public DateTime? OccuredDate { get; set; }

        public int? AdversaryId  { get; set; }
        public DynamicParameterValue Adversary { get; set; }

        public DateTime? ReportedDate { get; set; }

        public  string ReporterFirstName { get; set; }
        public string ReporterLastName { get; set; }

        public long? ReportedById  { get; set; }
        public Employee ReportedBy { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public DateTime? DetectionDate { get; set; }

        public string NotifierFirstName { get; set; }

        public string NotifierLastName { get; set; }


        public long? EmployeeId  { get; set; }
        public Employee Employee { get; set; }
        
        public string VoilationDetails { get; set; }

        public bool RepeatIncident { get; set; }

        public int? EffectId  { get; set; }
        public DynamicParameterValue Effect { get; set; }
        public int? CriticalityId  { get; set; }
        public DynamicParameterValue Criticality  { get; set; }

        
        public string Identification { get; set; }

        public string Correction { get; set; }
        public  string Eradication { get; set; }

        public string RecoveryMeasures { get; set; }

        public int? IncidentImpactId  { get; set; }
        public DynamicParameterValue IncidentImpact { get; set; }

        public string FollowUpAction { get; set; }

        public long? IncidentClosedById  { get; set; }
        public Employee IncidentClosedBy { get; set; }

        public long? FollowUpCompletedById  { get; set; }
        public Employee FollowUpCompletedBy { get; set; }

        public int? IncidentStatusId  { get; set; }
        public DynamicParameterValue IncidentStatus  { get; set; }

        public int? DetectedbyInternalControlsId  { get; set; }
        public DynamicParameterValue DetectedbyInternalControls  { get; set; }

        

    }
}
