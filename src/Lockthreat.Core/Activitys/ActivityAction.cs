using Abp.Domain.Entities.Auditing;
using Lockthreat.ActivityActions;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Activitys
{
   public class ActivityAction : FullAuditedEntity<long>
    {
        public long? ActivityId { get; set; }
        public Activity Activity { get; set; }
        public ActionType ActionType { get; set; }
        public ActionCategory ActionCategory { get; set; }
        public ActionTimeType ActionTimeType { get; set; }
        public int? ActionTime { get; set; }
        public string ActionTemplate { get; set; }

        public long? ActionRecipientsId { get; set; }
        public Employee ActionRecipients { get; set; }

        public long? ActionCCRecipientsId  { get; set; }
        public Employee ActionCCRecipients { get; set; }

        public long? ActionBCCRecipientsId  { get; set; }
        public Employee ActionBCCRecipients { get; set; }

        public long? ActionSMSId  { get; set; }
        public Employee ActionSMS { get; set; }

      
    }
}
