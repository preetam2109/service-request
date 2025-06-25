using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceRequestManager.Models
{
	public class ServiceRequest
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(50)]
        public string Status { get; set; } // e.g., "Open", "In Progress", "Closed"

        [Required]
        [StringLength(100)]
        public string CreatedBy { get; set; }
    }
}

