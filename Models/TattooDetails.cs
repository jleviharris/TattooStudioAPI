using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TattooStudioApi.Models
{
    public class TattooDetail
    {
        [Key]
        public Guid RowKey { get; set; } = Guid.NewGuid();

        [Required]
        public Guid SessionId { get; set; }

        [Required]
        public string NeedleType { get; set; }

        [Required]
        public string MachineUsed { get; set; }

        [Required]
        public string InkBrand { get; set; }

        public string AdditionalProducts { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("SessionId")]
        public Session Session { get; set; }
    }
}
