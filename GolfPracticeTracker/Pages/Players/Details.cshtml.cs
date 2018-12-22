using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GolfPracticeTracker.Models;

namespace GolfPracticeTracker.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly GolfPracticeTrackerContext _context;

        public DetailsModel(GolfPracticeTrackerContext context)
        {
            _context = context;
        }

        public Player Player { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = await _context.Players.FirstOrDefaultAsync(m => m.ID == id);

            if (Player == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
