using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Lockthreat.Business.Dto;
using Lockthreat.Organizations.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Business
{
    public interface IBusinessUnitAppService: IApplicationService
    {
        Task<PagedResultDto<BusinessUnitListDto>> GetAllBusinessUnits(GetBusinessUnitInput input);
        Task CreateOrUpdateBusinessUnit(CreateOrUpdateBusinessUnitInput input);
        Task DeleteBusinessUnit(EntityDto input);
        Task<GetBusinessUnitForEditDto> GetBusinessUnitForEdit(EntityDto input);
        string GetNextBusinessUnitId();
        Task<List<UpdateOrganizationUnitInput>> GetAllOrganizationUnits();
        Task<List<ParentUnit>> GetUnittypeWiesParent(UnitTypeInputDto input);
        Task<List<UnitTypeDto>> GetUnitType ();
        Task<List<BusinessUnitListDto>> GetAllparentUnit(UnitTypeInputDto input);

        Task<List<GetLockThreatOrganizationDto>> GetAllOraganization();
    }
}
