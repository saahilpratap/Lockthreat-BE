using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.IndustrySectors
{
    public class IndustrySector :FullAuditedEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
