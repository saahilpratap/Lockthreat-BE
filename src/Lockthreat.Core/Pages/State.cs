using Abp.Domain.Entities.Auditing;
using Lockthreat.ActivityActions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Lockthreat.Pages
{
 public  class State : FullAuditedEntity<long>
    {
        public long? PageId { get; set; }
        public Page Page { get; set; }

        [Required]
        public string StateName { get; set; }

        public bool StateType { get; set; }

        public bool IsStateOpen { get; set; }

        public int StateDeadline { get; set; }

        public ActionTimeType StateDeadlineType { get; set; }

        public bool IsStateActive { get; set; }
    }
}
