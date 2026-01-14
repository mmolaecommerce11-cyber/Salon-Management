using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Payments;

public class CheckoutModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CheckoutModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Salon_Management_System.Models.Booking Booking { get; set; } = null!;

    public SalonService Service { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int bookingId)
    {
        Booking = await _context.Bookings
            .Include(b => b.SalonService)
            .FirstOrDefaultAsync(b => b.Id == bookingId);

        if (Booking == null)
            return NotFound();

        if (Booking.Status != BookingStatus.PendingPayment)
            return BadRequest("Booking is not pending payment.");

        Service = Booking.SalonService!;

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int bookingId)
    {
        Booking = await _context.Bookings
            .FirstOrDefaultAsync(b => b.Id == bookingId);

        if (Booking == null)
            return NotFound();

        if (Booking.Status != BookingStatus.PendingPayment)
            return BadRequest();

        // PAYMENT GATEWAY WILL GO HERE (Stripe / PayFast)

        // Simulate successful payment
        Booking.Status = BookingStatus.Confirmed;

        await _context.SaveChangesAsync();

        return RedirectToPage("/Bookings/Confirmation", new { bookingId });
    }
}
