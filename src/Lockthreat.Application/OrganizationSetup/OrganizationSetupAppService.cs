using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Abp.Organizations;
using Abp.UI;
using Lockthreat.Authorization;
using Lockthreat.CodeGenerators;
using Lockthreat.Common;
using Lockthreat.Organization;
using Lockthreat.Organizations;
using Lockthreat.Organizations.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Lockthreat.OrganizationSetups;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.OrganizationSetup
{
    [AbpAuthorize(AppPermissions.Pages_Administration_OrganizationUnits)]
    public class OrganizationSetupAppService : LockthreatAppServiceBase, IOrganizationSetupAppService
    {
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly IOrganizationUnitAppService _organizationUnitAppService;
        private readonly OrganizationUnitManager _organizationUnitManager;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
      //  private readonly IRepository<CodeGenerator, long> _codegeneratorRepository;
        private readonly ICodeGeneratorCommonAppservice _codegeneratorRepository;
        public OrganizationSetupAppService(
            IRepository<LockThreatOrganization, long> organizationSetupRepository,
            IOrganizationUnitAppService organizationUnitAppService,
            OrganizationUnitManager organizationUnitManager,
            IRepository<OrganizationUnit, long> organizationUnitRepository, ICodeGeneratorCommonAppservice codegeneratorRepository)
        {
            _organizationSetupRepository = organizationSetupRepository;
            _organizationUnitAppService = organizationUnitAppService;
            _organizationUnitManager = organizationUnitManager;
            _organizationUnitRepository = organizationUnitRepository;
            _codegeneratorRepository = codegeneratorRepository;
        }

        public async Task<PagedResultDto<OrganizationSetupListDto>> GetAllOrgnizationSetup(GetOrganizationSetupInput input)
        {
            var query = _organizationSetupRepository.GetAll().Include(x => x.IndustrySector).Include(x => x.Country);

            var organizationSetupCount = await query.CountAsync();

            var organizationItems = await query
                .OrderBy(input.Sorting)
                .PageBy(input)
                .ToListAsync();

            var organizationListDtos = ObjectMapper.Map<List<OrganizationSetupListDto>>(organizationItems);
            return new PagedResultDto<OrganizationSetupListDto>(
               organizationSetupCount,
               organizationListDtos.ToList()
               ) ;
        }

        public async Task CreateOrUpdateOrganizationSetup(CreateOrUpdateOrganizationSetupInput input)
        {
            if (input.Id.HasValue)
            {
                await UpdateOrganizationSetup(input);
            }
            else
            {
                await CreateOrganizationSetup(input);
            }
        }

        protected virtual async Task CreateOrganizationSetup(CreateOrUpdateOrganizationSetupInput input)
        {
            try
            {
                bool isRootOrganizationExists = false;
                if (input.Leveltype == LevelType.Consortium)
                {
                    isRootOrganizationExists = _organizationUnitRepository.GetAll().Where(x => x.ParentId == null).Any();
                }
                else if (input.ParentOrganizationId == null && (input.Leveltype == LevelType.BusinessGroup || input.Leveltype == LevelType.Company))
                {
                    throw new UserFriendlyException("Please add Parent Organization(consortium).");
                }

                if (!isRootOrganizationExists)
                {
                    var organizationUnitCreateInput = new CreateOrganizationUnitInput()
                    {
                        DisplayName = input.CompanyName,
                        ParentId = input.ParentOrganizationId
                    };

                    //create organization unit
                    OrganizationUnitDto organizationUnitItem = await _organizationUnitAppService.CreateOrganizationUnit(organizationUnitCreateInput);

                    if (organizationUnitItem != null)
                    {
                        //create organization setup
                        if (!input.TenantId.HasValue)
                        {
                            input.TenantId = AbpSession.TenantId;
                        }

                        input.OrganizationUnitId = organizationUnitItem.Id;
                        input.CompanyId = _codegeneratorRepository.GetNextId(LockthreatConsts.Entity, "COM");
                        var organizationSetupInput = ObjectMapper.Map<LockThreatOrganization>(input);

                        await _organizationSetupRepository.InsertAsync(organizationSetupInput);
                        await _codegeneratorRepository.CodeCreate(LockthreatConsts.Entity, "COM");
                    }
                }
                else
                {
                    throw new UserFriendlyException("Root Organization Already Created, Cannot Create Another Root Organization.");
                }

            }
            catch (Exception e)
            {
                throw new UserFriendlyException(e.Message);
            }

        }


        protected virtual async Task UpdateOrganizationSetup(CreateOrUpdateOrganizationSetupInput input)
        {
            try
            {
                var organizationUnit = await _organizationUnitRepository.GetAsync((long)input.OrganizationUnitId); ;
                if (organizationUnit != null)
                {
                    if (organizationUnit.ParentId != input.ParentOrganizationId)
                    {
                        var moveOrganizationUnitInput = new MoveOrganizationUnitInput()
                        {
                            Id = organizationUnit.Id,
                            NewParentId = input.ParentOrganizationId
                        };
                        // move to new parent
                        await _organizationUnitAppService.MoveOrganizationUnit(moveOrganizationUnitInput);
                    }

                    var organizationUnitUpdateInput = new UpdateOrganizationUnitInput()
                    {
                        DisplayName = input.CompanyName,
                        Id = organizationUnit.Id
                    };
                    // update Organization Unit
                    OrganizationUnitDto organizationUnitItem = await _organizationUnitAppService.UpdateOrganizationUnit(organizationUnitUpdateInput);
                }
                else
                {
                    throw new UserFriendlyException("CannotFindOrganizationUnit");
                }

                //update organization setup 
                var organizationItem = await _organizationSetupRepository.GetAsync((long)input.Id);
                ObjectMapper.Map(input, organizationItem);
                await _organizationSetupRepository.UpdateAsync(organizationItem);
            }
            catch (Exception )
            {
                throw new UserFriendlyException("Cannot Update Organization");
            }

        }

        public async Task<GetOrganizationForEditDto> GetOrganizationForEdit(EntityDto input)
        {
            GetOrganizationForEditDto organizationItem = new GetOrganizationForEditDto();
            var organizationSetup = await _organizationSetupRepository.GetAll().Include(x => x.IndustrySector).Include(x => x.Country).Where(x => x.Id == input.Id).FirstOrDefaultAsync();

            if (organizationSetup != null)
            {
                organizationItem = ObjectMapper.Map<GetOrganizationForEditDto>(organizationSetup);
            }
            return organizationItem;
        }


        public async Task<long> GetOrganizationByOrganizationUnitId(EntityDto input)
        {
            var organizationItem = await _organizationSetupRepository.GetAll().IgnoreQueryFilters().Where(c => c.OrganizationUnitId == input.Id && !c.IsDeleted).FirstOrDefaultAsync();
            if (organizationItem != null)
            {
                return organizationItem.Id;
            }
            else
            {
                return 0;
            }
        }

        public string GetNextCompanyId()
        {
            string nextOrganizationSetupId = "";
            var OrganizationItem = _organizationSetupRepository.GetAllListAsync();
            if (OrganizationItem != null)
            {
                nextOrganizationSetupId = "COM-" + (OrganizationItem.Id + 1);
            }
            else
            {
                nextOrganizationSetupId = "COM-1";
            }

            return nextOrganizationSetupId;
        }

        [AbpAllowAnonymous]
        public async Task<List<GetOrganizationDto>> GetAllOrganization()
        {
            var organizationItem = new List<GetOrganizationDto>();
            var getOrganization = await _organizationSetupRepository.GetAll().ToListAsync();

            if (getOrganization.Count() != 0)
            {
                organizationItem = ObjectMapper.Map<List<GetOrganizationDto>>(getOrganization);
            }
            return organizationItem;
        }


    }
    
}
