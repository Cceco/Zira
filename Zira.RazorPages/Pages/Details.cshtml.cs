using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zira.RazorPages.Data;
using Zira.RazorPages.Data.Models;

namespace Zira.RazorPages.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

      public Details Details { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
         {
            if (id == null || _context.Details == null)
            {
                return NotFound();
            }

            Details = await _context.Details
                .Include(d => d.FactSheets)
                .FirstOrDefaultAsync(m => m.Id == id);

            return Page();
        }
    }
}
