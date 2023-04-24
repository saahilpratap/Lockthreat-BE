using Abp.Domain.Entities.Auditing;
using Lockthreat.AuthoratativeDocuments ;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.BusinessProcesses
{
    [Table("BusinessProcessAuthoratativeDocuments")]
    public class BusinessProcessAuthoratativeDocument : FullAuditedEntity<long>
    {
        public long? BusinessProcessId  { get; set; }
        public BusinessProcess BusinessProcess  { get; set; }

        public long? AuthoratativeDocumentId { get; set; }
        public AuthoratativeDocument AuthoratativeDocument { get; set; }
    }
}
