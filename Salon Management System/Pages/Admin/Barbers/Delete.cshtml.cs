using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Admin.Barbers;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Barber Barber { get; private set; } = null!;

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Barber = await _context.Barbers
            .FirstOrDefaultAsync(b => b.Id == id);

        if (Barber == null)
        {
            return NotFound();
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id)
    {
        var barber = await _context.Barbers
            .FirstOrDefaultAsync(b => b.Id == id);

        if (barber == null)
        {
            return NotFound();
        }

        bool hasBookings = await _context.Bookings
            .AnyAsync(b => b.BarberId == id);

        if (hasBookings)
        {
            Barber = barber;
            ModelState.AddModelError(string.Empty,
                "This barber has existing bookings and cannot be deleted.");
            return Page();
        }

        _context.Barbers.Remove(barber);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
