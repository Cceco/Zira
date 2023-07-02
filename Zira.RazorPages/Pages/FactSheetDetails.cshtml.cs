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
    public class FactSheetDetailsModel : PageModel
    {
        private readonly Zira.RazorPages.Data.ApplicationDbContext _context;

        public FactSheetDetailsModel(Zira.RazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public FactSheet FactSheet { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.FactSheet == null)
            {
                return NotFound();
            }

            var factsheet = await _context.FactSheet.FirstOrDefaultAsync(m => m.Id == id);
            if (factsheet == null)
            {
                return NotFound();
            }
            else 
            {
                FactSheet = factsheet;
            }
            return Page();
        }
    }
}
