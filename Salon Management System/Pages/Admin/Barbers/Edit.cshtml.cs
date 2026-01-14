using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Admin.Barbers;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;

    [BindProperty]
    public Barber Barber { get; set; } = null!;

    public EditModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Barber = await _context.Barbers.FindAsync(id);

        if (Barber == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.Attach(Barber).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
