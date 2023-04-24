using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Common
{
  public  interface ICodeGeneratorCommonAppservice : IApplicationService
    {
        Task CodeCreate(string Title, string Code);

        string GetNextId(string title, string code);
    }
}
