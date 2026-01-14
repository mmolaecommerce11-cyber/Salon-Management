namespace Salon_Management_System.Models;

public class Payment
{
    public int Id { get; set; }

    public int BookingId { get; set; }
    public Booking Booking { get; set; } = null!;

    public decimal Amount { get; set; }
    public string ProviderReference { get; set; } = null!;
    public DateTime PaidAt { get; set; }
}
