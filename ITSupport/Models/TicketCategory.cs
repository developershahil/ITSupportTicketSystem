using System.ComponentModel.DataAnnotations;

namespace ITSupport.Models
{
    public class TicketCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
