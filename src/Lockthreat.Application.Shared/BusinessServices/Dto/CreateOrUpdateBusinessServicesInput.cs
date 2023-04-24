using Lockthreat.ITservices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.BusinessServices.Dto
{
    public class CreateOrUpdateBusinessServicesInput
    {
        public long? Id { get; set; }
        public int? TenantId { get; set; }
        public string BusinessServiceId { get; set; } 
        public string BusinessServiceName { get; set; } 
        public long? BusinessUnitDependentId { get; set; } 
        public long? BusinessUnitprimaryId { get; set; } 
        public long? CompanyNameId { get; set; } 
        public long? BusinessServiceOwnerId { get; set; } 
        public long? BusinessServiceManagerId { get; set; } 
        public int? ServiceTypeId { get; set; } 
        public int? ConfidentialityId { get; set; } 
        public int? IntergrityId { get; set; } 
        public int? OthersId { get; set; }
        public int? AvailibilityId { get; set; }
        public List<BusinessUnitDto> BusinessUnits  { get; set; }

        public List<GetITserviceForBusinessServiceDto> ITservices  { get; set; }

      //  public List<>
    }
}
