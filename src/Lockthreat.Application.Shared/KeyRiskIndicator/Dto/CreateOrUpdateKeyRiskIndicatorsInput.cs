using Lockthreat.BusinessServices.Dto;
using Lockthreat.OrganizationSetup.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.KeyRiskIndicator.Dto
{
    public class CreateOrUpdateKeyRiskIndicatorsInput 
    {
        public long? Id { get; set; }
        public int? TenantId { get; set; } 
        public string KeyRiskIndicatorsId { get; set; } 
        public int? StatusId { get; set; } 
      
        public string KeyRiskIndicatorTitle { get; set; } 
        public string Description { get; set; }
        public long? LockThreatOrganizationId { get; set; }
        public List<GetOrganizationDto> CompanyLists { get; set; }

        public List<BusinessUnitPrimaryDto> BusinessUnits { get; set; }

        public List<BusinessUnitKeyRiskDto> SelectdBusinessUnits { get; set; }

    }

    public class BusinessUnitKeyRiskDto
    {
        public long Id { get; set; }
        public long? KeyRiskIndicatorId { get; set; }
        public long? BusinessUnitId { get; set; }

    }
}
