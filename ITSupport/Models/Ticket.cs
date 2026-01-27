using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITSupport.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int PriorityId { get; set; }

        [StringLength(20)]
        public string Status { get; set; } = TicketStatus.Open;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        // 🔹 NEW (VERY IMPORTANT)
        public int CreatedBy { get; set; }          // Support user
        public int? AssignedTo { get; set; }        // Technician user

        [ForeignKey("CategoryId")]
        public TicketCategory? Category { get; set; }

        [ForeignKey("PriorityId")]
        public TicketPriority? Priority { get; set; }
    }

    // Status constants
    public static class TicketStatus
    {
        public const string Open = "Open";
        public const string InProgress = "In Progress";
        public const string Closed = "Closed";
    }
}
