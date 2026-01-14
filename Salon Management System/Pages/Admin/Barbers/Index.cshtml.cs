using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Admin.Barbers;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IList<Barber> Barbers { get; set; } = new List<Barber>();

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task OnGetAsync()
    {
        Barbers = await _context.Barbers
            .OrderBy(b => b.FullName)
            .ToListAsync();
    }
}
