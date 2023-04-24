using Abp.Domain.Entities.Auditing;
using Abp.DynamicEntityParameters;
using Lockthreat.BusinessEntities;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.BusinessServices
{
    [Table("BusinessServiceUnits")]
    public class BusinessServiceUnit  : FullAuditedEntity<long>
    {
        public long? BusinessServiceId  { get; set; }
        public BusinessService BusinessService  { get; set; }
        public long? BusinessUnitId  { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        
       
    }
}
