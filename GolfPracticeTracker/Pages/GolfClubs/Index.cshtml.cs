using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GolfPracticeTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GolfPracticeTracker.Pages.GolfClubs
{
    public class IndexModel : PageModel
    {
        private readonly GolfPracticeTrackerContext _context;

        public IndexModel(GolfPracticeTrackerContext context)
        {
            _context = context;
        }

        public IList<GolfClub> GolfClub { get;set; }

        public async Task OnGetAsync()
        {
            // Method syntax
            GolfClub = await _context.GolfClubs
                .Where(gc => gc.InBag &&
                        gc.PlayerID == 1).ToListAsync();

            // Query syntax
            GolfClub = await (from gc in _context.GolfClubs
                where gc.InBag &&
                      gc.PlayerID == 1
                select gc).ToListAsync(); ;
        }
    }
}
