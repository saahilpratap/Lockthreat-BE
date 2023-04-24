using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Contracts.Dto
{
 public class ContractInputDto : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }
        public string ContractId { get; set; }
        public string ContractTitle { get; set; }
        public string ContractReference { get; set; }
        public string Description { get; set; }
        public int? ContractValue { get; set; }      
        public string ContractType { get; set; }
        public string ContractCategory { get; set; }
        public string Vendor { get; set; }
        public string LockThreatOrganization { get; set; }      
        public long? OrganizationId { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "contractId,contractTitle,contractReference,description DESC";
            }

            Filter = Filter?.Trim();
        }
    }
}
