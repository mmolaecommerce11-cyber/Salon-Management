using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Bookings;

public class ConfirmationModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public ConfirmationModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Salon_Management_System.Models.Booking Booking { get; set; } = null!;
    public SalonService Service { get; set; } = null!;
    public Barber Barber { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int bookingId)
    {
        Booking = await _context.Bookings
            .Include(b => b.SalonService)
            .Include(b => b.Barber)
            .FirstOrDefaultAsync(b => b.Id == bookingId);

        if (Booking == null)
            return NotFound();

        if (Booking.Status != BookingStatus.Confirmed)
            return BadRequest("Booking is not confirmed.");

        if (Booking.SalonService == null || Booking.Barber == null)
            return BadRequest("Booking data incomplete.");

        Service = Booking.SalonService;
        Barber = Booking.Barber;

        return Page();
    }
}
