using Abp.Runtime.Validation;
using Lockthreat.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lockthreat.Employee.Dto
{
    public class GetEmployeeInput : PagedAndSortedInputDto, IShouldNormalize
    {
        public string Filter { get; set; }
        public long? OrganizationId { get; set; }
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "name,employeeId,dateOfBirth,email,directPhone DESC";
            }

            Filter = Filter?.Trim();
        }
    }
}
