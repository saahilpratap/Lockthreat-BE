using Abp.Domain.Entities.Auditing;
using Lockthreat.BusinessEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.AuthoratativeDocuments
{
    [Table("AuthoratativeDocumentBusinessUnits")]
    public   class AuthoratativeDocumentBusinessUnit: FullAuditedEntity<long>
    {

        public long? AuthoratativeDocumentsId { get; set; }
        public AuthoratativeDocument AuthoratativeDocuments { get; set; }

        public long? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit  { get; set; }
    }
}
