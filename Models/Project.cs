using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TattooStudioApi.Models
{
    public class Project
    {
        [Key]
        public Guid RowKey { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string ProjectName { get; set; }

        public string Description { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Ongoing"; // Ongoing, Completed, Abandoned

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
