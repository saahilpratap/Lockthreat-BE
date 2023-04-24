using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Lockthreat.Contracts.Dto;
using Lockthreat.DataExporting.Excel.NPOI;
using Lockthreat.Dto;
using Lockthreat.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contracts.ExportExcel
{

    public class ContractExcelExporter : NpoiExcelExporterBase, IContractExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public ContractExcelExporter(
           ITimeZoneConverter timeZoneConverter,
           IAbpSession abpSession,
           ITempFileCacheManager tempFileCacheManager)
           : base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }
        public FileDto ExportToFile(List<ContractListDto> input,string fileName )
        {
            return CreateExcelPackage(
             fileName + ".xlsx",
             excelPackage =>
             {
                 var sheet = excelPackage.CreateSheet(L("Users"));
                 AddHeader(
                   sheet,
                   L(fileName)
                   );

                 AddHeader(
                    sheet,
                    L("")
                    );

                 AddHeader(
                     sheet,
                        "Contract ID",
                        "Title",
                        "Category",
                        "Contract Type",                       
                        "Description",
                        "Vendors",
                        "Company Name"
                     );
                 AddObjects(
                     sheet, 2, input,
                     _ => _.ContractId,
                      _ => _.ContractTitle,
                      _ => _.ContractCategory,
                      _ => _.ContractType,
                      _ => _.Description,
                      _ => _.Vendor,
                      _ => _.LockThreatOrganization
                     );
             });

           
        }
    }
}
