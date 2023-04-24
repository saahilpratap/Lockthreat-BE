using Abp.Application.Services.Dto;
using Abp.DynamicEntityParameters;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.StrategicObjectives.Dto
{
  public  class StrategicObjectiveDto: EntityDto<long>
    {
        public int? TenantId { get; set; }
        public string StrategicObjectiveId { get; set; }
        public long? ExecutiveSponsorId { get; set; }

        public List<ProgramUser> ExecutiveSponsors { get; set; }

        public string StrategicObjectiveTitle { get; set; }
        public string Description { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public int? StatusId { get; set; }

        public  List<GetDynamicValueDto> Statuses  { get; set; }

        public int? TypeId { get; set; }
        public List<GetDynamicValueDto> Types  { get; set; }

        public string Goal { get; set; }
        public List<OranizationGoalDto> Goals  { get; set; }

        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> LockThreatOrganizations  { get; set; }
    }

    public class OranizationGoalDto
    {
        public long Id { get; set; }
        public string Goal { get; set; }
        public long? LockThreatOrganizationId { get; set; }
    }

}
