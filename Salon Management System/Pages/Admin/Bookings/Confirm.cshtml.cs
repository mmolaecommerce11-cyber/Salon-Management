using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Admin.Bookings
{
    public class ConfirmModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ConfirmModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Booking Booking { get; private set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Booking = await _context.Bookings
                .Include(b => b.SalonService)
                .Include(b => b.Barber)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (Booking == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = BookingStatus.Confirmed;
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
