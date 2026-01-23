using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Admin.Services
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SalonService> Services { get; set; } = new List<SalonService>();

        public async Task OnGetAsync()
        {
            Services = await _context.SalonServices
                .OrderBy(s => s.Name)
                .ToListAsync();
        }
    }
}
