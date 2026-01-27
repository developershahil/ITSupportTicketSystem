using System.ComponentModel.DataAnnotations;

namespace ITSupport.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; } // hashed later

        [Required]
        public string Role { get; set; } // Admin / Support / Technician

        public bool IsActive { get; set; } = true;
    }
}
