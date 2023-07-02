using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Zira.RazorPages.Data;
using Zira.RazorPages.Data.Models;

namespace Zira.RazorPages.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Zira.RazorPages.Data.ApplicationDbContext _context;

        public DetailsModel(Zira.RazorPages.Data.ApplicationDbContext context)
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

            var details = await _context.Details
                .Include(d => d.FactSheets)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (details == null)
            {
                return NotFound();
            }
            else 
            {
                Details = details;
            }
            return Page();
        }
    }
}
