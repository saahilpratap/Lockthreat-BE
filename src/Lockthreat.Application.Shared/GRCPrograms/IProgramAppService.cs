using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.GRCPrograms.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.GRCPrograms
{
    public interface IProgramAppService : IApplicationService
    {
        Task<ProgramDto> GetProgramInfo(long? programId);

        Task AddorEditProgram(ProgramDto program);

        Task RemoveProgramTeamMember(long id);

        Task RemoveProgramCoordinator(long id);

        Task RemoveProgramAuthoratativeDocument(long id);


        Task RemoveProgram(long programId);

        Task RemoveProgramCountry(long id);

        Task<PagedResultDto<ProgramListDto>> GetAllPrograms(ProgramListInput input);
    }
}
