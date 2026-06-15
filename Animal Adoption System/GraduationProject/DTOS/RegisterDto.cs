using System.ComponentModel.DataAnnotations;

namespace GraduationProject.DTOS
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required] 
        public string DisplayName { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Password must be strong (Upper, Lower, Number, Symbol, 8+ chars)")]
        public string Password { get; set; }
    }
}
