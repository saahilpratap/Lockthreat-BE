using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.ApplicationConfigurations
{
    [Table("ApplicationConfigurations")]
    public  class ApplicationConfiguration : FullAuditedEntity<long>, IMayHaveTenant
    {
        public int? TenantId { get; set; }

        public string FieldName { get; set; }

        public string DisplayValue { get; set; }

        public string Value { get; set; }

        public string SubValue { get; set; }

        public int? NumberValue { get; set; }

        public Decimal? NumberDecimal { get; set; }

    }
}
