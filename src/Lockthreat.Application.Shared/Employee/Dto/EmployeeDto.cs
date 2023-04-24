using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Employee.Dto
{
    public class EmployeeDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string EmployeeId { get; set; }

        public string EmployeePosition { get; set; }

        public long LockThreatOrganizationId  { get; set; }

        public string LockThreatOrganization { get; set; }

    }
}
