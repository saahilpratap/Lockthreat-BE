using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.Pages
{
  public  class Page : FullAuditedEntity<long>
    {
        [Required]
        public string PageName { get; set; }

        public string PageDescription { get; set; }

        public bool IsPageActive { get; set; }
    }
}
