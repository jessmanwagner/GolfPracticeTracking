using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfPracticeTracker.Models;

namespace GolfPracticeTracker.Pages.Players
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
        public Player Player { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyPlayer = new Player();

            // Using TryUpdateModel to update fields with posted values is a security best practice because it prevents overposting. 
            // For example, suppose the Player entity includes a Secret property that this web page shouldn't update or add:
            // Even if the app doesn't have a Secret field on the create/update Razor Page, a hacker could set the Secret value by overposting. 
            // A hacker could use a tool such as Fiddler, or write some JavaScript, to post a Secret form value. 
            if (await TryUpdateModelAsync<Player>(emptyPlayer, "Player", p => p.FirstName, p => p.LastName))
            {
                _context.Players.Add(Player);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}