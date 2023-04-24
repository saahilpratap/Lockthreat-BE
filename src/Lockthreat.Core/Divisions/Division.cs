using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Divisions
{
    public class Division :FullAuditedEntity
    {
        public string Name { get; set; }
       
    }
}
