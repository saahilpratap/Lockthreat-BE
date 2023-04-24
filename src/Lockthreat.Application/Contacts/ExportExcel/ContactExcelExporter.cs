using Abp.Runtime.Session;
using Abp.Timing.Timezone;
using Lockthreat.Contacts.Dto;
using Lockthreat.DataExporting.Excel.EpPlus;
using Lockthreat.DataExporting.Excel.NPOI;
using Lockthreat.Dto;
using Lockthreat.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contacts.ExportExcel
{
    public class ContactExcelExporter : NpoiExcelExporterBase, IContactExcelExporter
    {
        private readonly ITimeZoneConverter _timeZoneConverter;
        private readonly IAbpSession _abpSession;

        public ContactExcelExporter(
            ITimeZoneConverter timeZoneConverter,
            IAbpSession abpSession,
            ITempFileCacheManager tempFileCacheManager)
            : base(tempFileCacheManager)
        {
            _timeZoneConverter = timeZoneConverter;
            _abpSession = abpSession;
        }

        public FileDto ExportToFile(List<ContactListViewDto> input , string fileName)
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
                         "Contact ID",
                         "Name",
                         "Job Title",
                         "Direct Phone",
                         "Email",
                         "Phone",
                         "Contact Owner",
                         "Vendors",
                         "Company Name"
                       );
                   AddObjects(
                       sheet, 2, input,
                       _ => _.ContactId,
                       _ => _.FirstName+" "+_.LastName,
                       _ => _.jobTitle,
                       _ => _.PhoneNumber,
                       _ => _.Email,
                       _ => _.MobileNo,
                       _ => _.LoginUser,
                       _ => _.Vendor ,
                       _ => _.LockThreatOrganization
                       );
               });


        }
    }
}
