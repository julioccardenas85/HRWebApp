namespace FlamingSoftHR.Shared.Models
{
    public partial class LoggedTimeType
    {
        public LoggedTimeType()
        {
            LoggedTimes = new HashSet<LoggedTime>();
        }

        public int Id { get; set; }
        public string Description { get; set; } = null!;

        public virtual ICollection<LoggedTime> LoggedTimes { get; set; }
    }
}
