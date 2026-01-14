using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;


namespace Salon_Management_System.Pages.Bookings;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    // Display data
    public SalonService Service { get; set; } = null!;
    public List<Barber> Barbers { get; set; } = new();

    // Form input
    [BindProperty]
    public BookingInputModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int serviceId)
    {
        Service = await _context.SalonServices
            .FirstOrDefaultAsync(s => s.Id == serviceId && s.IsActive);

        if (Service == null)
            return NotFound();

        Barbers = await _context.Barbers
            .Where(b => b.IsActive)
            .ToListAsync();

        Input.SalonServiceId = serviceId;
        Input.AppointmentDate = DateTime.Today.AddDays(1);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        Service = await _context.SalonServices
            .FirstOrDefaultAsync(s => s.Id == Input.SalonServiceId);

        if (Service == null)
            return NotFound();

        // Auto-assign barber if none selected
        int barberId = Input.BarberId ??
            await GetAvailableBarberAsync(Input.AppointmentDate);

        if (barberId == 0)
        {
            ModelState.AddModelError("", "No barbers available for the selected time.");
            return Page();
        }

        // Prevent double booking
        bool slotTaken = await _context.Bookings.AnyAsync(b =>
            b.BarberId == barberId &&
            b.AppointmentDate == Input.AppointmentDate);

        if (slotTaken)
        {
            ModelState.AddModelError("", "Selected time is no longer available.");
            return Page();
        }

        var booking = new Salon_Management_System.Models.Booking
        {
            SalonServiceId = Input.SalonServiceId,
            BarberId = barberId,
            AppointmentDate = Input.AppointmentDate,
            CustomerName = Input.CustomerName,
            CustomerEmail = Input.CustomerEmail,
            Status = BookingStatus.PendingPayment
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return RedirectToPage("/Payments/Checkout", new { bookingId = booking.Id });
    }

    private async Task<int> GetAvailableBarberAsync(DateTime date)
    {
        var barberIds = await _context.Barbers
            .Where(b => b.IsActive)
            .Select(b => b.Id)
            .ToListAsync();

        foreach (var barberId in barberIds)
        {
            bool isBooked = await _context.Bookings.AnyAsync(b =>
                b.BarberId == barberId &&
                b.AppointmentDate == date);

            if (!isBooked)
                return barberId;
        }

        return 0;
    }

    public class BookingInputModel
    {
        public int SalonServiceId { get; set; }

        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; } = null!;

        public DateTime AppointmentDate { get; set; }

        public int? BarberId { get; set; }
    }
}
