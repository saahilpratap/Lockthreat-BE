using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Vendors.Dto
{
  public  class VendorExcelInputDto
    {
        public string Filter { get; set; }
        public string VendorId { get; set; }
        public string VendorName { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string Email { get; set; }
        public string CellPhoneNumber { get; set; }
        public string Address { get; set; }
        public string VendorType { get; set; }
        public string Industry { get; set; }
        public string VendorCriticalRating { get; set; }
        public string VendorInitialRating { get; set; }
    }
}
