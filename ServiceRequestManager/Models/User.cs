using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceRequestManager.Models
{
	public class User
	{
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Hashed password
    }
}

