using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TattooStudioApi.Models
{
    public class Session
    {
        [Key]
        public Guid RowKey { get; set; } = Guid.NewGuid();

        [Required]
        public Guid AppointmentId { get; set; }

        [Required]
        public Guid ProjectId { get; set; }

        public string Notes { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("AppointmentId")]
        public Appointment Appointment { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
