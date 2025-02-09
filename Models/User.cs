using System.ComponentModel.DataAnnotations;

namespace TattooStudioApi.Models
{
    public class User
    {
        [Key]
        public Guid RowKey { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public string Role { get; set; } = "TattooArtist";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
