using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlamingSoftHR.Shared.Models.Request
{
    public class LoggedTimeTypeRequest
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
    }
}
