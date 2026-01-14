public class Booking
{
    public int Id { get; set; }

    public string CustomerId { get; set; }
    public int BarberId { get; set; }
    public int StyleId { get; set; }

    public DateTime AppointmentTime { get; set; }
    public BookingStatus Status { get; set; }

    public decimal Price { get; set; }
}
public enum BookingStatus
{
    Pending,
    Paid,
    Cancelled
}
