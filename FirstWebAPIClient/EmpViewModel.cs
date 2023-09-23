namespace FirstWebAPI.Models
{
    public class EmpViewModel
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Title { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public String? City { get; set; } = String.Empty;
        public int? ReportsTo { get; set; }

    }
}