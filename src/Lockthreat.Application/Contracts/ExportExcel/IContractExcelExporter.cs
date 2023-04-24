using Lockthreat.Contracts.Dto;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contracts.ExportExcel
{
   public interface IContractExcelExporter
    {
        FileDto ExportToFile(List<ContractListDto> input, string fileName);
    }
}
