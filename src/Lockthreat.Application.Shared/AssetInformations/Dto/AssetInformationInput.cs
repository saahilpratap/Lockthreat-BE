﻿using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.AssetInformations.Dto
{
 public  class AssetInformationInput : PagedAndSortedInputDto, IShouldNormalize
    { 
        public string Filter { get; set; }

        public long? OrganizationId { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "assetTitle,assetId DESC";
            }

            Filter = Filter?.Trim();
        }
    }
}
