namespace Salon_Management_System.Models;

public class Booking
{
    public int Id { get; set; }

    public int SalonServiceId { get; set; }
    public SalonService SalonService { get; set; } = null!;

    public int BarberId { get; set; }
    public Barber Barber { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }

    public string CustomerName { get; set; } = null!;
    public string CustomerEmail { get; set; } = null!;
    public string CustomerPhone { get; set; } = null!;   // ✅ REQUIRED

    public BookingStatus Status { get; set; }
}
