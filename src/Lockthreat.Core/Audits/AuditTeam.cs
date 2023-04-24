﻿using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Lockthreat.Audits 
{
    [Table("AuditTeams")]
    public   class AuditTeam : FullAuditedEntity<long>
    {
        public long? AuditId { get; set; }
        public Audit  Audit { get; set; }

        public long? EmployeeId  { get; set; }
        public Employee Employee  { get; set; }
    }
}
