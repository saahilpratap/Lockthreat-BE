using Abp.Domain.Entities.Auditing;
using Lockthreat.Activitys;
using Lockthreat.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.Templates
{
 public   class Template : FullAuditedEntity<long>
    {
        [Required]
        public string TemplateTitle { get; set; }

        public string TemplateDescription { get; set; }

        [Required]
        public string TemplateSubject { get; set; }

        [Required]
        public string TemplateBody { get; set; }

        [Required]
        public string TemplateType { get; set; }

        public long? StateId { get; set; }
        public State State { get; set; }

        public long? ActivityId { get; set; }
        public Activity Activity { get; set; }

    }
}
