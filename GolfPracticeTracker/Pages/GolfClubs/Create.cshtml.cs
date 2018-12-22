
using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfPracticeTracker.Models;

namespace GolfPracticeTracker.Pages.GolfClubs
{
    public class CreateModel : PageModel
    {
        private readonly GolfPracticeTrackerContext _context;

        public CreateModel(GolfPracticeTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GolfClub GolfClub { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GolfClubs.Add(GolfClub);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}