namespace Salon_Management_System.Models;

public class Barber
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public bool IsActive { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
