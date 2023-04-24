using Abp.Domain.Entities.Auditing;
using Lockthreat.Employees;
using Lockthreat.Exceptions;


namespace Lockthreat.Employees 
{
  public  class EmployeeException : FullAuditedEntity<long>
    {
        public long? EmployeesId { get; set; }
        public Employee Employees { get; set; }
        public long? ExceptionId  { get; set; }
        public Exception Exception  { get; set; }
    }
}
