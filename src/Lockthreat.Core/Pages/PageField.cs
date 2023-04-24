using Abp.Domain.Entities.Auditing;
using Lockthreat.Activitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Pages
{
  public   class PageField : FullAuditedEntity<long>
    {
        public long? PageId  { get; set; }
        public Page Page { get; set; }

        public string PageFieldName { get; set; }

        public string PageFieldDescription { get; set; }

        public bool PageFieldType { get; set; }

        public bool FieldIsMandatory  { get; set; }

        public bool FieldIsPII { get; set; }

        public bool FieldIsEnc { get; set; }

        public bool FieldIsVis { get; set; }
    }
}
