using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Admin.Bookings;

public class CancelModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public CancelModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Booking Booking { get; set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Booking = await _context.Bookings
            .FirstOrDefaultAsync(b => b.Id == id);

        if (Booking == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (Booking == null)
        {
            return NotFound();
        }

        // Update the status to Canceled
        Booking.Status = BookingStatus.Canceled;

        _context.Bookings.Update(Booking);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
