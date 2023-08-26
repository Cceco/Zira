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
    public class FactSheetDeleteModel : PageModel
    {
        private readonly Zira.RazorPages.Data.ApplicationDbContext _context;

        public FactSheetDeleteModel(Zira.RazorPages.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public FactSheetViewModel FactSheet { get; set; } = default!;

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
                FactSheet = new FactSheetViewModel
                {
                    Id = factsheet.Id,
                    DocumentName = factsheet.DocumentName,
                    DocumentSlimFilePath = factsheet.DocumentSlimFilePath,
                    Frequency = factsheet.Frequency,
                    OutputType = factsheet.OutputType,
                    SerialNumber = factsheet.SerialNumber,
                    MultiLanguage = factsheet.MultiLanguage,
                    CustomFont = factsheet.CustomFont,
                    CustomColorScheme = factsheet.CustomColorScheme,
                    Notes = factsheet.Notes,
                    HardcodedSection = factsheet.HardcodedSection,
                    NarrativeManager = factsheet.NarrativeManager,
                    DetailsId = factsheet.DetailsId,
                };
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.FactSheet == null)
            {
                return NotFound();
            }
            var factsheet = await _context.FactSheet.FindAsync(id);
            var detailsId = factsheet.DetailsId;

            if (factsheet != null)
            {
                _context.FactSheet.Remove(factsheet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Details", new { id = detailsId });
        }
    }
}
