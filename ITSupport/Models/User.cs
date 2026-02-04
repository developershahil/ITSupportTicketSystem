using System.ComponentModel.DataAnnotations;

namespace ITSupport.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        // Store hashed password only
        [StringLength(512)]
        public string? PasswordHash { get; set; }

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = "Support";

        public bool IsActive { get; set; } = true;
    }
}