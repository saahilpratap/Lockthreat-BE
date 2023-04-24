
using Abp.Domain.Repositories;
using Abp.DynamicEntityParameters;
using Lockthreat.DynamicEntityParameters.Dto;
using Lockthreat.OrganizationSetup.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.UI;
namespace Lockthreat.DynamicParameterAll
{
 public  class DynamicParameterAppService : IDynamicParameterAppService
    {
        private readonly IRepository<DynamicParameterValue> _DynamicParameterValueRepository;
        private readonly IRepository<DynamicParameter> _dynamicParameterManager;

        public DynamicParameterAppService(
          IRepository<DynamicParameterValue> DynamicParameterValueRepository,
          IRepository<DynamicParameter> dynamicParameterManager
          )
        {
            _DynamicParameterValueRepository = DynamicParameterValueRepository;
            _dynamicParameterManager = dynamicParameterManager;
        }


        

    }
}
