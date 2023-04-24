using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contacts.Dto
{
 public class ContactExcelInputDto
    {
        public string Filter { get; set; }
        public long? OrganizationId { get; set; }
        public string ContactId { get; set; }
        public string FirstName { get; set; }
        public string jobTitle { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string LoginUserFilter { get; set; }
        public string LockThreatOrganizationFilter { get; set; }
        public string VendorFilter { get; set; }
    }
}
