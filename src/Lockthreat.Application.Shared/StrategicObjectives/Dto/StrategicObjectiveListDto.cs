using Abp.Application.Services.Dto;
using Abp.DynamicEntityParameters;
using Lockthreat.GRCPrograms.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.StrategicObjectives.Dto
{
 public   class StrategicObjectiveListDto : EntityDto<long>
    {      
        public string StrategicObjectiveId { get; set; }
        public long? ExecutiveSponsorId { get; set; }
        public ProgramUser ExecutiveSponsor { get; set; }

        public string StrategicObjectiveTitle { get; set; }
        public string Description { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public int? StatusId { get; set; }
        public DynamicParameterValue Status { get; set; }

        public int? TypeId { get; set; }
        public DynamicParameterValue Type { get; set; }

        public string Goal { get; set; }

        public long? LockThreatOrganizationId { get; set; }
        public GetOrganizationDto LockThreatOrganization { get; set; }


    }
}
