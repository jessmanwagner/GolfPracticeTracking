using System.Linq;
using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfPracticeTracker.Models;

namespace GolfPracticeTracker.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly GolfPracticeTrackerContext _context;

        public EditModel(GolfPracticeTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players.FindAsync(id);

            if (Player == null)
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

            _context.Attach(Player).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Player.ID))
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

        private bool PlayerExists(int id)
        {
            return _context.Players.Any(e => e.ID == id);
        }

        // option way to handle the OnPostAsync with TryUpdateModelAsync and passing in optional id
        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    var studentToUpdate = await _context.Players.FindAsync(id);

        //    if (await TryUpdateModelAsync<Player>(
        //        studentToUpdate,
        //        "student",
        //        s => s.FirstName, s => s.LastName))
        //    {
        //        await _context.SaveChangesAsync();
        //        return RedirectToPage("./Index");
        //    }

        //    return Page();
        //}
    }
}
