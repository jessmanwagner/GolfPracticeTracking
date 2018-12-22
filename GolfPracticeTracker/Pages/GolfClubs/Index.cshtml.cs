using System.Collections.Generic;
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
            GolfClub = await _context.GolfClubs.ToListAsync();
        }
    }
}
