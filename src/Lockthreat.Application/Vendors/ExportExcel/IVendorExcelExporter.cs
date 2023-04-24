using Lockthreat.Dto;
using Lockthreat.Vendors.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Vendors.ExportExcel
{
    public interface IVendorExcelExporter 
    {
        FileDto ExportToFile(List<GetVendorListDto> input, string fileName);
    }
}
