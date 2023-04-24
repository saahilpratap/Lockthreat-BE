using Abp.Domain.Entities.Auditing;
using Lockthreat.Remediations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.ITServices
{
  public  class ITServiceRemediation  : FullAuditedEntity<long>
    {
        public long? ITServiceId  { get; set; }
        public ITService ITService { get; set; }

        public long? RemediationId  { get; set; }
        public Remediation Remediation { get; set; }

    }
}
