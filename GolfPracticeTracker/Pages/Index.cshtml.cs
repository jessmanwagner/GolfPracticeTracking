using System.Linq;
using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using GolfPracticeTracker.Models;
//using GolfPracticeTracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GolfPracticeTracker.Pages
{
    public class IndexModel : PageModel
    {
        private readonly GolfPracticeTrackerContext _context;

        public IndexModel(GolfPracticeTrackerContext context)
        {
            _context = context;
        }

        //private ClubAverageStats ClubAverageStats { get; set; }

        public int PlayerID { get; set; }   // setting to me for now - I'm the only player until login added

        public void OnGetAsync(int? id = 1)
        {
            if (id != null)
            {
                PlayerID = id.Value;

                Player player = _context.Players.Single(p => p.ID == PlayerID);
            }

            // with the player id, load clubs and practice sessions
            //ClubAverageStats.Player = _context.Players
            //    .Include(p => p.GolfClubs)
            //    .Include(p => p.PracticeSessions).Where(p => p.ID == PlayerID);
            // with practice sessions, load the stats

            // for each club in a practice session, calculate the averages for the dashboard

            //ClubAverageStats = new ClubAverageStats();
            //ClubAverageStats.Player = _context.Players.FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}
