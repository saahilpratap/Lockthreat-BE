using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.IndustrySectors.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.OrganizationSetup.Dto
{
    public class OrganizationSetupListDto : EntityDto<long>, IPassivable, IHasCreationTime
    { 
        public string CompanyName { get; set; }
        public string CompanyId { get; set; }

        public int? IndustrySectorId { get; set; }
        public DynamicParameterValue IndustrySector { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; } 
        public DateTime CreationTime { get; set; }
    }
}
