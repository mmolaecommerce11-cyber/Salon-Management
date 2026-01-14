using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Salon_Management_System.Data;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Style> Styles { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? CategoryId { get; set; }

    public void OnGet()
    {
        var query = _context.Styles
            .Include(s => s.Category)
            .AsQueryable();

        if (!string.IsNullOrEmpty(Search))
            query = query.Where(s => s.Name.Contains(Search));

        if (CategoryId.HasValue)
            query = query.Where(s => s.CategoryId == CategoryId);

        Styles = query.ToList();
    }
}
