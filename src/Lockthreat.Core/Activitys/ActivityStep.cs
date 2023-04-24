using Abp.Domain.Entities.Auditing;
using Lockthreat.ActivityActions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Activitys
{
 public   class ActivityStep : FullAuditedEntity<long>
    {
        public long? ActivityId { get; set; }
        public Activity Activity { get; set; }
        public string ActivityCriteria { get; set; }
        public int ActivityActors { get; set; }
        public bool IsActivityMand { get; set; }
        public bool ActivityType { get; set; }
        public int ActivityDuration { get; set; }
        public ActionTimeType ActivityDurationType { get; set; }
        public string ActivityAutoCon { get; set; }
    }
}
