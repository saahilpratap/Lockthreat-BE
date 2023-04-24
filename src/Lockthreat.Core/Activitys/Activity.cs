using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.Activitys
{
   public class Activity : FullAuditedEntity<long>
    {
        [Required]
        public string ActivityName  { get; set; }

        [Required]
        public string  ActivityDescription { get; set; }

        [Required]
        public string  ActivityCurrentStep { get; set; }
    }
}
