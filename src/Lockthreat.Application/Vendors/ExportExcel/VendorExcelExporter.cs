using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Lockthreat.DataExporting.Excel.NPOI;
using Lockthreat.Dto;
using Lockthreat.Storage;
using Lockthreat.Vendors.Dto;
using System;
using System.Collections.Generic;


namespace Lockthreat.Vendors.ExportExcel
{
 public  class VendorExcelExporter : NpoiExcelExporterBase,IVendorExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public VendorExcelExporter (
           ITimeZoneConverter timeZoneConverter,
           IAbpSession abpSession,
           ITempFileCacheManager tempFileCacheManager)
           : base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }
        public FileDto ExportToFile(List<GetVendorListDto> input, string fileName)
        {
            return CreateExcelPackage(
            fileName + ".xlsx",
            excelPackage =>
            {
                var sheet = excelPackage.CreateSheet(L("Users"));
              
                AddHeader(
                    sheet,
                       "Vendor ID",
                       "Vendor Name",
                       "Vendor Type ",
                       "Contact Name",
                       "Industry",
                       "Address",
                       "Email",
                       "Cell Phone",
                       "Phone Number"
                    );
                AddObjects(
                    sheet, 2, input,                    
                     _ => _.VendorId,
                     _ => _.VendorName,
                     _ => _.VendorType.Value,
                     _ => _.ContactFirstName+" "+ _.ContactLastName,
                     _ => _.Industry.Value,
                     _ => _.Address+" ,"+_.State+","+_.City+","+_.PostalCode,
                     _ => _.Email,
                     _ => _.CellPhoneNumber,
                     _ => _.PhoneNumber
                    );
            });
        }
    }
}
