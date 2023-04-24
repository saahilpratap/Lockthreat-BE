using Lockthreat.Contacts.Dto;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contacts.ExportExcel
{
   public interface IContactExcelExporter
    {
        FileDto ExportToFile(List<ContactListViewDto> lots, string fileName);

    }
}
