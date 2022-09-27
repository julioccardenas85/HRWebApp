using System;
using System.Collections.Generic;

namespace FlamingSoftHR.Shared.Models
{
    public partial class LoggedTime
    {
        public int Id { get; set; }
        public DateTime DateLogged { get; set; } = DateTime.Now;
        public double Hours { get; set; }
        public int LogType { get; set; }
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; } = null!;
        public virtual LoggedTimeType LogTypeNavigation { get; set; } = null!;
    }
}
