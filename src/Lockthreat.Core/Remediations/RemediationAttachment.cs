using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Remediations 
{
   public class RemediationAttachment : FullAuditedEntity<long>
    {
        public long? RemediationId  { get; set; }
        public Remediation Remediation  { get; set; }

        public string AttachmentTitle { get; set; }

        public string Description { get; set; }

        public string Documents { get; set; }

    }
}
