using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Bookings;

public class MyBookingsModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public MyBookingsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty(SupportsGet = true)]
    public string? Email { get; set; }

    public IList<Booking> Bookings { get; set; } = new List<Booking>();

    public async Task OnGetAsync()
    {
        if (string.IsNullOrWhiteSpace(Email))
            return;

        Bookings = await _context.Bookings
            .Include(b => b.SalonService)
            .Include(b => b.Barber)
            .Where(b => b.CustomerEmail == Email)
            .OrderByDescending(b => b.AppointmentDate)
            .ToListAsync();
    }
}
