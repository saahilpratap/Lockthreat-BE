using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.RiskTreatments 
{
  public  class RiskTreatmentAttachment : FullAuditedEntity<long>
    {
        public long? RiskTreatmentId  { get; set; }
        public RiskTreatment RiskTreatment { get; set; }
        public string Title { get; set; }
        public long? EmployeeId  { get; set; }
        public Employee Employee { get; set; }
        
        public string Notes { get; set; }

    }
}
