using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TattooStudioApi.Models
{
    public class Client
    {
        [Key]
        public Guid RowKey { get; set; } = Guid.NewGuid();

        [Required]
        public Guid UserId { get; set; } // Foreign key

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public string? Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}

