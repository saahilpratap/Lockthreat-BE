using Abp.Application.Services;
using Lockthreat.IndustrySectors.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.IndustrySectors
{
  public  interface IIndustrySectorAppService : IApplicationService
    {
     
        
        Task<List<IndustrySectorDto>> GetAll ();
    }
}
