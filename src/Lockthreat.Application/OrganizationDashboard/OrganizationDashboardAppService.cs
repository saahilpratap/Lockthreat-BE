using Abp.Domain.Repositories;
using Lockthreat.BusinessEntities;
using Lockthreat.BusinessProcesses;
using Lockthreat.BusinessServices;
using Lockthreat.ITServices;
using Lockthreat.OrganizationDashboard.Dto;
using Lockthreat.OrganizationSetups;
using Lockthreat.StrategicObjectives;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.OrganizationDashboard
{
  public  class OrganizationDashboardAppService : LockthreatAppServiceBase, IOrganizationDashboardAppService
    {
        private readonly IRepository<ITService, long> _itservicesRepository;
        private readonly IRepository<BusinessUnit, long> _businessUnitRepository;
        private readonly IRepository<BusinessProcess, long> _businessProcessRepository;
        private readonly IRepository<BusinessService, long> _businessServicesRepository;
        private readonly IRepository<LockThreatOrganization, long> _organizationSetupRepository;
        private readonly IRepository<StrategicObjective, long> _strategicObjectiveRepository;
        private readonly IRepository<KeyRiskIndicators.KeyRiskIndicator, long> _KeyRiskIndicatorsRepository;
        private readonly IRepository<KeyPerformanceIndicators.KeyPerformanceIndicator, long> _KeyPerformanceIndicatorsRepository;
        public OrganizationDashboardAppService(
           IRepository<ITService, long> itservicesRepository,
           IRepository<BusinessUnit, long> businessUnitRepository,
           IRepository<BusinessProcess, long> businessProcessRepository,
           IRepository<BusinessService, long> businessServicesRepository,
           IRepository<LockThreatOrganization, long> organizationSetupRepository,
           IRepository<StrategicObjective, long> strategicObjectiveRepository,
           IRepository<KeyRiskIndicators.KeyRiskIndicator, long> KeyRiskIndicatorsRepository,
           IRepository<KeyPerformanceIndicators.KeyPerformanceIndicator, long> KeyPerformanceIndicatorsRepository                     
           )
        {
            _itservicesRepository = itservicesRepository;
            _businessUnitRepository = businessUnitRepository;
            _businessProcessRepository = businessProcessRepository;
            _organizationSetupRepository = organizationSetupRepository;
            _businessServicesRepository = businessServicesRepository;
            _strategicObjectiveRepository = strategicObjectiveRepository;
            _KeyRiskIndicatorsRepository = KeyRiskIndicatorsRepository;
            _KeyPerformanceIndicatorsRepository = KeyPerformanceIndicatorsRepository;
        }

        public async Task<OrganizationCountDto> GetOrganizationDashboardCount()
        {
            var query = new OrganizationCountDto();
            try
            {
                OrganizationCountDto count = new OrganizationCountDto();
                count.OrganizationCount = await _organizationSetupRepository.GetAll().CountAsync();
                count.StrategicObjectiveCount = await _strategicObjectiveRepository.GetAll().CountAsync();
                count.BusinessProcessCount = await _businessProcessRepository.GetAll().CountAsync();
                count.BusinessServieCount = await _businessServicesRepository.GetAll().CountAsync();
                count.BusinessUnitCount = await _businessUnitRepository.GetAll().CountAsync();
                count.ITserviceCount = await _itservicesRepository.GetAll().CountAsync();
                count.KPICount = await _KeyPerformanceIndicatorsRepository.GetAll().CountAsync();
                count.KRICount = await _KeyRiskIndicatorsRepository.GetAll().CountAsync();
                query = count;

                return query;
            }
            catch(Exception ex)
            {
                throw;
            }

        }

    }
}
