using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TattooStudioApi.Models
{
    public class ClientNote
    {
        [Key]
        public Guid RowKey { get; set; } = Guid.NewGuid();

        [Required]
        public Guid ClientId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public string NoteText { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("ClientId")]
        public Client Client { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
