using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.StrategicObjectives.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.StrategicObjectives
{
 public  interface IStrategicObjectivesAppService: IApplicationService
    {
           Task<StrategicObjectiveDto> GetStrategicObjectiveInfo(long? StrategicObjectiveId);
           Task<PagedResultDto<StrategicObjectiveListDto>> GetAllStrategicObjectives(GetStrategicObjectiveInputDto input);
           Task CreateOrUpdateStrategicObjectives(StrategicObjectiveDto input);
           Task DeleteStrategicObjective(EntityDto input);
          Task<GetEditStrategicObjectiveDto> GetStrategicObjectiveEdit(EntityDto input);
    }
}
