using Abp.Domain.Entities.Auditing;
using Lockthreat.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.RiskTreatments 
{
  public  class RiskTreatmentVendor : FullAuditedEntity<long>
    {

        public long? VendorId { get; set; }  
        public Vendor Vendor { get; set; }

        public long? RiskTreatmentId  { get; set; }
        public RiskTreatment RiskTreatment  { get; set; }

        


    }
}
