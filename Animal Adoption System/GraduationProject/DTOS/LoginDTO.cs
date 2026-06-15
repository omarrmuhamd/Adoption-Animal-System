using System.ComponentModel.DataAnnotations;

namespace GraduationProject.DTOS
{
    public class LoginDTO
    {
        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
