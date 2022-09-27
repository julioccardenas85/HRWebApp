using System;
using System.Collections.Generic;

namespace FlamingSoftHR.Shared.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
