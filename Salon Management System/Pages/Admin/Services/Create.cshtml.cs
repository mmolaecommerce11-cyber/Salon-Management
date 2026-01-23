using Microsoft.AspNetCore.Mvc;               // 🔥 REQUIRED for [BindProperty]
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;              // 🔥 REQUIRED for IFormFile
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Admin.Services
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateModel(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public SalonService Service { get; set; } = new();

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public void OnGet()
        {
            // Default new services to active
            Service.IsActive = true;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            // 🔒 Force active so public Services page can see it
            Service.IsActive = true;

            // IMAGE UPLOAD
            if (ImageFile != null)
            {
                string uploadsFolder = Path.Combine(
                    _environment.WebRootPath,
                    "images/services"
                );

                Directory.CreateDirectory(uploadsFolder);

                string uniqueFileName =
                    Guid.NewGuid() + Path.GetExtension(ImageFile.FileName);

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using var fileStream = new FileStream(filePath, FileMode.Create);
                await ImageFile.CopyToAsync(fileStream);

                Service.ImagePath = "/images/services/" + uniqueFileName;
            }

            _context.SalonServices.Add(Service);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
