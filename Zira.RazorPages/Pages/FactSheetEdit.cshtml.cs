using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zira.RazorPages.Data;
using Zira.RazorPages.Data.Models;

namespace Zira.RazorPages.Pages
{
    public class FactSheetEditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public FactSheetEditModel(ApplicationDbContext context)
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

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingFactSheet = await _context.FactSheet.FindAsync(FactSheet.Id);
            if (existingFactSheet == null)
            {
                return NotFound();
            }

            existingFactSheet.Id = FactSheet.Id;
            existingFactSheet.DocumentName = FactSheet.DocumentName;
            existingFactSheet.DocumentSlimFilePath = FactSheet.DocumentSlimFilePath;
            existingFactSheet.Frequency = FactSheet.Frequency;
            existingFactSheet.OutputType = FactSheet.OutputType;
            existingFactSheet.SerialNumber = FactSheet.SerialNumber;
            existingFactSheet.MultiLanguage = FactSheet.MultiLanguage;
            existingFactSheet.CustomFont = FactSheet.CustomFont;
            existingFactSheet.CustomColorScheme = FactSheet.CustomColorScheme;
            existingFactSheet.Notes = FactSheet.Notes;
            existingFactSheet.HardcodedSection = FactSheet.HardcodedSection;
            existingFactSheet.NarrativeManager = FactSheet.NarrativeManager;

            await _context.SaveChangesAsync();

            return RedirectToPage("./FactSheetDetails", new { id = existingFactSheet.Id });
        }
    }
}
