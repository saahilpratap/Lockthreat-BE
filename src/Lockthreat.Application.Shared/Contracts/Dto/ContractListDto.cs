using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contracts.Dto
{
  public  class ContractListDto : EntityDto<long>
    {
        public int? TenantId { get; set; }
        public string ContractId { get; set; }
        public string ContractTitle { get; set; }
        public string ContractReference { get; set; }
        public string Description { get; set; }
        public int? ContractValue { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }        
        public string ContractType { get; set; }
        public string ContractCategory { get; set; }
        public string Vendor { get; set; }
        public string LockThreatOrganization { get; set; }
        public string Employee { get; set; }
    }
     
}
