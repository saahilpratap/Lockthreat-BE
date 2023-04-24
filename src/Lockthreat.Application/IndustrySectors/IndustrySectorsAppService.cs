using Abp.Domain.Repositories;
using Abp.DynamicEntityParameters;
using Lockthreat.IndustrySectors.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.IndustrySectors
{


    public class IndustrySectorsAppService : IIndustrySectorAppService
    {
        private readonly IRepository<DynamicParameterValue> _DynamicParameterValueRepository;
        private readonly IRepository<DynamicParameter> _dynamicParameterManager;

        public IndustrySectorsAppService(
          IRepository<DynamicParameterValue> DynamicParameterValueRepository, 
          IRepository<DynamicParameter> dynamicParameterManager
          )
        {
            _DynamicParameterValueRepository = DynamicParameterValueRepository;
            _dynamicParameterManager = dynamicParameterManager;
        }
        public async Task<List<IndustrySectorDto>> GetAll()
        {
            var getIndustrySector = new List<IndustrySectorDto>();
            try
            {
                var getcheckId = _dynamicParameterManager.FirstOrDefault(x => x.ParameterName.ToLower().Trim() == "industry sector");
                if (getcheckId != null)
                {
                     getIndustrySector = await _DynamicParameterValueRepository.GetAll()
                        .Where(l => l.DynamicParameterId == getcheckId.Id)
                         .Select(x => new IndustrySectorDto()
                         {
                             Id = x.Id,
                             Name = x.Value,
                         }).ToListAsync();

                    return getIndustrySector;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return getIndustrySector;
        }
    }
}
