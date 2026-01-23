using Microsoft.AspNetCore.Mvc;                // 🔥 REQUIRED FOR BindProperty
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;
using Salon_Management_System.Models;

namespace Salon_Management_System.Pages.Services
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<SalonService> Services { get; set; } = new List<SalonService>();

        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? Category { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<SalonService> query = _context.SalonServices
                .Where(s => s.IsActive);

            if (!string.IsNullOrWhiteSpace(Search))
            {
                query = query.Where(s => s.Name.Contains(Search));
            }

            if (!string.IsNullOrWhiteSpace(Category))
            {
                query = query.Where(s => s.Category == Category);
            }

            Services = await query
                .OrderBy(s => s.Category)
                .ThenBy(s => s.Name)
                .ToListAsync();
        }
    }
}
