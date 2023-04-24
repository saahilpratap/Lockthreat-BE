using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.AuthoratativeDocument.Dto
{
    public class AuthoratativeDocumentsDto : FullAuditedEntity<long>
    {
        public int? TenantId { get; set; }

        public string AuthorityDocumentId { get; set; }

        public string AuthorityDocumentOrigin { get; set; }

        public string AuthoratativeDocumentTitle { get; set; }

        public int? MandateTypeId { get; set; }
        public int? TypeId { get; set; }
        public string Keywords { get; set; }

        public string AuthoratativeDocumentName { get; set; }

        public string DocumentURL { get; set; }

        public string Logo { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public string Notes { get; set; }

        public string ImportantNotice { get; set; }

    }
}
