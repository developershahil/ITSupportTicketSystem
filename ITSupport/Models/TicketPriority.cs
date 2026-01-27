using System.ComponentModel.DataAnnotations;

namespace ITSupport.Models
{
    public class TicketPriority
    {
        [Key]
        public int PriorityId { get; set; }

        [Required]
        [StringLength(20)]
        public string PriorityName { get; set; }
    }
}
