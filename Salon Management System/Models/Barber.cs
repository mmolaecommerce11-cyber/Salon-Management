using System.ComponentModel.DataAnnotations;

namespace Salon_Management_System.Models
{
    public class Barber
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FullName { get; set; } = null!;

        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }  // optional if you want

        [Phone]
        [StringLength(20)]
        public string? Phone { get; set; }  // optional if you want

        public bool IsActive { get; set; } = true;

        // Optional: navigation properties
        // public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
