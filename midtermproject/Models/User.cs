namespace midtermproject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty; 
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        // additional info
        public string? DateOfBirth { get; set; }
        public string? Bio { get; set; }
        public string? Disability { get; set; }
        public string? AccessibilityNeeds { get; set; }
        public string? Gender { get; set; }

        // Contact Information
        public string? MobileNumber { get; set; }
        public string? EmergencyContact { get; set; }
        public string? Address { get; set; }
    }
}
