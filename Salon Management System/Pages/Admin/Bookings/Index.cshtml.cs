using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Admin.Bookings;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Booking> Bookings { get; set; } = new List<Booking>();

    public async Task OnGetAsync()
    {
        Bookings = await _context.Bookings
            .Include(b => b.SalonService)
            .Include(b => b.Barber)
            .OrderByDescending(b => b.AppointmentDate)
            .ToListAsync();
    }
}
