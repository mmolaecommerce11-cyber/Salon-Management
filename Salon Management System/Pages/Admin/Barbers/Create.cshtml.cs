using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Admin.Barbers;

public class CreateModel : PageModel
{
    private readonly ApplicationDbContext _context;

    [BindProperty]
    public Barber Barber { get; set; } = new();

    public CreateModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public void OnGet()
    {
        Barber.IsActive = true;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        _context.Barbers.Add(Barber);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
