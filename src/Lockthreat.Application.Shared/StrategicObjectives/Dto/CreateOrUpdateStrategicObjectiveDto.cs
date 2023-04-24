using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.StrategicObjectives.Dto
{
 public  class CreateOrUpdateStrategicObjectiveDto
    {
        public long? Id { get; set; }
        public int? TenantId { get; set; }
        public string StrategicObjectiveId { get; set; }
        public long? ExecutiveSponsorId { get; set; }      
        public string StrategicObjectiveTitle { get; set; }
        public string Description { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public int? StatusId { get; set; }
       
        public int? TypeId { get; set; }
      

        public int? GoalId { get; set; }
   

        public long? LockThreatOrganizationId { get; set; }
       
    }
}
