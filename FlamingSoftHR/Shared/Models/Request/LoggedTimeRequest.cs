namespace FlamingSoftHR.Shared.Models.Request
{
    public class LoggedTimeRequest
    {
        public int Id { get; set; }
        public DateTime DateLogged { get; set; }
        public double Hours { get; set; }
        public int LogType { get; set; }
        public int EmployeeId { get; set; }
    }
}
