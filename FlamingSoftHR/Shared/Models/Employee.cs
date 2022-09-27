using System;
using System.Collections.Generic;


namespace FlamingSoftHR.Shared.Models
{
    public partial class Employee
    {
        public Employee()
        {
            LoggedTimes = new HashSet<LoggedTime>();
        }

        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public int DepartmentId { get; set; }
        public int EmployeeTypeId { get; set; }

        public virtual Department Department { get; set; } = null!;
        public virtual EmployeeType EmployeeType { get; set; } = null!;
        public virtual AspNetUser User { get; set; } = null!;
        public virtual ICollection<LoggedTime> LoggedTimes { get; set; }
    }
}
