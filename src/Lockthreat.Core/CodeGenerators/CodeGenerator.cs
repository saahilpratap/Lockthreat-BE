using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.CodeGenerators
{
    [Table("IDGenerators")]
    public  class CodeGenerator: FullAuditedEntity<long>
    {
        public string Title { get; set; }

        public string Code { get; set; }

        public long? value { get; set; }
    }
}
