using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.Countries
{
    public class Country :FullAuditedEntity
    {
        [Required]
        public string CountryCode { get; set; }

        [Required]      
        public string Name { get; set; }

        public bool IsActive { get; set; }

       
    }
}
