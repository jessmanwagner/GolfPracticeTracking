using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfPracticeTracker.Models;

namespace GolfPracticeTracker.Pages.GolfClubs
{
    public class EditModel : PageModel
    {
        private readonly GolfPracticeTrackerContext _context;

        public EditModel(GolfPracticeTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GolfClub GolfClub { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GolfClub = await _context.GolfClubs.FirstOrDefaultAsync(m => m.ID == id);

            if (GolfClub == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GolfClub).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GolfClubExists(GolfClub.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GolfClubExists(int id)
        {
            return _context.GolfClubs.Any(e => e.ID == id);
        }
    }
}
