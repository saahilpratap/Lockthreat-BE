using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Departments
{
    public class Department:FullAuditedEntity
    {
        public string Name { get; set; }
       
    }
}
