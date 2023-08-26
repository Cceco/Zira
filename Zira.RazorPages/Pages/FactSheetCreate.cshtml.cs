using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Zira.RazorPages.Data;
using Zira.RazorPages.Data.Models;

namespace Zira.RazorPages.Pages
{
    public class FactSheetCreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public FactSheetCreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (Request.Query.TryGetValue("id", out StringValues idValues))
            {
                ClientId = int.Parse(idValues[0]);
            }

            return Page();
        }

        [BindProperty]
        public FactSheetViewModel FactSheet { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int ClientId { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var client = await _context.Clients
                .Where(c => c.Id == ClientId)
                .Include(c => c.Details)
                .FirstOrDefaultAsync();

            if (!ModelState.IsValid
                || _context.FactSheet == null
                || FactSheet == null
                || client == default)
            {
                return Page();
            }

            if (client.Details == null) 
            {
                client.Details = new Details();
            }

            var details = client.Details;

            var newFactSheet =
                new FactSheet
                    {
                        DocumentName = FactSheet.DocumentName,
                        DocumentSlimFilePath = FactSheet.DocumentSlimFilePath,
                        Frequency = FactSheet.Frequency,
                        OutputType = FactSheet.OutputType,
                        SerialNumber = FactSheet.SerialNumber,
                        MultiLanguage = FactSheet.MultiLanguage,
                        CustomFont = FactSheet.CustomFont,
                        CustomColorScheme = FactSheet.CustomColorScheme,
                        Notes = FactSheet.Notes,
                        HardcodedSection = FactSheet.HardcodedSection,
                        NarrativeManager = FactSheet.NarrativeManager,
                    };

            if (details.FactSheets == null)
            {
                details.FactSheets = new List<FactSheet>
                {
                    newFactSheet
                };
            }
            else
            {
                details.FactSheets.Add(newFactSheet);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("./Details", new { id = details.Id });
        }
    }

    public class FactSheetViewModel
    {
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public string DocumentSlimFilePath { get; set; }
        public string Frequency { get; set; }
        public string OutputType { get; set; }
        public string SerialNumber { get; set; }
        public string MultiLanguage { get; set; }
        public string CustomFont { get; set; }
        public string CustomColorScheme { get; set; }
        public string Notes { get; set; }
        public string HardcodedSection { get; set; }
        public string NarrativeManager { get; set; }
        public int DetailsId { get; set; }
    }
}
