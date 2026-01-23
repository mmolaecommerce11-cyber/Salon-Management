using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Admin.Services
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public DeleteModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public SalonService Service { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Service = await _context.SalonServices.FindAsync(id);

            if (Service == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var service = await _context.SalonServices.FindAsync(Service.Id);

            if (service == null)
                return NotFound();

            // 🧹 Delete image file (optional but recommended)
            if (!string.IsNullOrEmpty(service.ImagePath))
            {
                var imagePath = Path.Combine(
                    _environment.WebRootPath,
                    service.ImagePath.TrimStart('/')
                );

                if (System.IO.File.Exists(imagePath))
                {
                    System.IO.File.Delete(imagePath);
                }
            }

            _context.SalonServices.Remove(service);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}