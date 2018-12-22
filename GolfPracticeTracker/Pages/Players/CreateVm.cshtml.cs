using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using GolfPracticeTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GolfPracticeTracker.Pages.Players
{
    public class CreateVmModel : PageModel
    {
        private readonly GolfPracticeTrackerContext _context;

        public CreateVmModel(GolfPracticeTrackerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PlayerVM PlayerVM { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Player());
            entry.CurrentValues.SetValues(PlayerVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}