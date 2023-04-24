using Abp.Domain.Repositories;
using Lockthreat.CodeGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lockthreat.Common
{
  public  class CodeGeneratorCommonAppservice :ICodeGeneratorCommonAppservice 
    {
        private readonly IRepository<CodeGenerator, long> _codegeneratorRepository;

        public CodeGeneratorCommonAppservice(IRepository<CodeGenerator, long> codegeneratorRepository)
        {
            _codegeneratorRepository = codegeneratorRepository;
        }

        public async Task CodeCreate(string Title, string Code)
        {
            CodeGenerator code = new CodeGenerator();
            var getlastId = _codegeneratorRepository.GetAll().Where(x => x.Title == Title).OrderByDescending(x => x.Id).FirstOrDefault();
            if (getlastId != null)
            {
                if (getlastId.Id != 0)
                {
                    var businessItem = await _codegeneratorRepository.GetAsync((long)getlastId.Id);
                    if (businessItem != null)
                    {
                        businessItem.Title = businessItem.Title;
                        businessItem.value = ((businessItem.value) + 1);
                        await _codegeneratorRepository.UpdateAsync(businessItem);
                    }
                }
                else
                {
                    code.Title = Title;
                    code.Code = Code;
                    code.value = 1;
                    await _codegeneratorRepository.InsertAsync(code);
                }
            }
            else
            {
                code.Title = Title;
                code.Code = Code;
                code.value = 1;
                await _codegeneratorRepository.InsertAsync(code);
            }

        }

        public string GetNextId(string title,string code)
        {
            string nextOrganizationSetupId = "";
            var OrganizationItem = _codegeneratorRepository.GetAll().Where(x => x.Title == title).OrderByDescending(x => x.Id).FirstOrDefault();
            if (OrganizationItem != null)
            {
                nextOrganizationSetupId = code +"-"+ (OrganizationItem.value + 1);
            }
            else
            {
                nextOrganizationSetupId = code+"-"+1;
            }

            return nextOrganizationSetupId;
        }

    }
}
