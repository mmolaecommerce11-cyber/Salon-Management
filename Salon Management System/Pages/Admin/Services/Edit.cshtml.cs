using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Admin.Services;

public class EditModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _environment;

    public EditModel(ApplicationDbContext context, IWebHostEnvironment environment)
    {
        _context = context;
        _environment = environment;
    }

    [BindProperty]
    public SalonService Service { get; set; } = null!;

    [BindProperty]
    public IFormFile? ImageFile { get; set; }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        Service = await _context.SalonServices.FindAsync(id);

        if (Service == null)
            return NotFound();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        if (ImageFile != null)
        {
            string uploadsFolder = Path.Combine(_environment.WebRootPath, "images/services");
            Directory.CreateDirectory(uploadsFolder);

            string uniqueFileName = Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await ImageFile.CopyToAsync(stream);

            Service.ImagePath = "/images/services/" + uniqueFileName;
        }

        _context.Update(Service);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }
}
