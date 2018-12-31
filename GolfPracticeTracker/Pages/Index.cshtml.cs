using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using GolfPracticeTracker.Models;
using GolfPracticeTracker.Models.ViewModels;
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

        public List<PracticeSummaryVM> ClubAverages { get; set; }

        public int PlayerID { get; set; }

        public string PlayerName { get; set; }

        public async Task OnGetAsync(int? id = 1)
        {
            var allPlayersInfo = await _context.Players
                .Include(p => p.GolfClubs)
                .Include(p => p.PlayerPracticeSessionAssignments)
                .ThenInclude(p => p.PracticeSession)
                .ThenInclude(p => p.GolfShots).ToListAsync();

            if (id != null)
            {
                PlayerID = id.Value;
                Player player = _context.Players.Single(p => p.ID == PlayerID);
                PlayerName = player.FullName;
                // Todo: Include all below in 'if' or early exit back to page?

                var golfClubs = _context.GolfClubs.Where(gc => gc.PlayerID == PlayerID && gc.InBag)
                    .OrderBy(so => so.SortOrder);
                var playerPracticeSessions =
                    player.PlayerPracticeSessionAssignments.Select(s => s.PracticeSession).ToList();
                var practiceSessionAssignments =
                    _context.PlayerPracticeSessionAssignments.Where(p => p.PlayerID == PlayerID);

                var practicesWithShotAggregates = playerPracticeSessions
                    .Join(practiceSessionAssignments, ps => ps.ID, psa => psa.PlayerPracticeSessionAssignmentID,
                        (ps, psa) => new {ps, psa})
                    .Join(golfClubs, pspsa => pspsa.psa.GolfClubID, gc => gc.ID, (pspsa, gc) => new {pspsa, gc})
                    .Select(x => new PracticeSummaryVM()
                    {
                        ClubName = x.gc.Name,
                        PracticeDate = x.pspsa.ps.PracticeDate,
                        GolfShots = x.pspsa.ps.GolfShots,
                        CarryAveYds = x.pspsa.ps.GolfShots.Sum(gs => gs.CarryYards),
                        TotalAveYds = x.pspsa.ps.GolfShots.Sum(gs => gs.TotalYards),
                        NumberOfShotsLeft = x.pspsa.ps.GolfShots.Where(gs => gs.OfflineYards <= 0).Select(gs => gs.OfflineYards).Count(),
                        NumberOfShotsRight = x.pspsa.ps.GolfShots.Where(gs => gs.OfflineYards >= 0).Select(gs => gs.OfflineYards).Count(),
                        OfflineLeft = x.pspsa.ps.GolfShots.Where(gs => gs.OfflineYards <= 0).Select(gs => gs.OfflineYards).Sum(),
                        OfflineRight = x.pspsa.ps.GolfShots.Where(gs => gs.OfflineYards >= 0).Select(gs => gs.OfflineYards).Sum(),
                        NumberOfShots = x.pspsa.ps.GolfShots.Count
                    }).ToList();

                // Todo: write this in method syntax and write all other LINQ queries in sql syntax for practice
                var clubsWithAverages = from practiceAggregates in practicesWithShotAggregates
                    group practiceAggregates by practiceAggregates.ClubName
                    into groupedClubs
                    select new PracticeSummaryVM()
                    {
                        ClubName = groupedClubs.Key,
                        NumberOfShots = groupedClubs.Sum(shot => shot.NumberOfShots),
                        CarryAveYds = groupedClubs.Sum(shot => shot.CarryAveYds) / groupedClubs.Sum(shot => shot.NumberOfShots),
                        TotalAveYds = groupedClubs.Sum(shot => shot.TotalAveYds) / groupedClubs.Sum(shot => shot.NumberOfShots),
                        OfflineLeft = groupedClubs.Sum(shot => shot.OfflineLeft) / groupedClubs.Sum(shot => shot.NumberOfShots),
                        OfflineRight = groupedClubs.Sum(shot => shot.OfflineRight) / groupedClubs.Sum(shot => shot.NumberOfShots),
                        NumberOfShotsLeft = groupedClubs.Sum(shot => shot.NumberOfShotsLeft),
                        NumberOfShotsRight = groupedClubs.Sum(shot => shot.NumberOfShotsRight),
                    };

                ClubAverages = new List<PracticeSummaryVM>();
                foreach (var golfClub in golfClubs)
                {
                    var club = new PracticeSummaryVM();
                    if (clubsWithAverages.Any(c => c.ClubName == golfClub.Name))
                    {
                        ClubAverages.Add(clubsWithAverages.FirstOrDefault(c => c.ClubName == golfClub.Name));
                    }
                    else
                    {
                        club.ClubName = golfClub.Name;
                        ClubAverages.Add(club);
                    }
                }
            }
        }
    }
}
