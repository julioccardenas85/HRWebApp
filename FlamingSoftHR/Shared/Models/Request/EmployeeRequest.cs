namespace FlamingSoftHR.Shared.Models.Request
{
    public class EmployeeRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public int EmployeeTypeId { get; set; }
    }
}
