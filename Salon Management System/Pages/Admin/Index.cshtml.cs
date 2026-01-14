using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;

namespace Salon_Management_System.Pages.Admin;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public int TotalBookings { get; set; }
    public int PendingPayments { get; set; }
    public int ActiveServices { get; set; }
    public int ActiveBarbers { get; set; }

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        TotalBookings = await _context.Bookings.CountAsync();
        PendingPayments = await _context.Bookings.CountAsync(b => b.Status == Models.BookingStatus.PendingPayment);
        ActiveServices = await _context.SalonServices.CountAsync(s => s.IsActive);
        ActiveBarbers = await _context.Barbers.CountAsync(b => b.IsActive);
    }
}
