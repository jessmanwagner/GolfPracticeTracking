using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using GolfPracticeTracker.Models;
using GolfPracticeTracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GolfPracticeTracker.Pages.PracticeSummary
{
    public class PracticeSummaryModel : PageModel
    {
        private readonly GolfPracticeTrackerContext _context;

        public PracticeSummaryModel(GolfPracticeTrackerContext context)
        {
            _context = context;
        }

        public List<PracticeSummaryVM> PracticeSummaryList { get; set; }

        public int PlayerID { get; set; }

        public string PlayerName { get; set; }

        public async Task OnGet(int? id = 1)
        {
            Player player = new Player();

            var allPlayersInfo = await _context.Players
                .Include(p => p.GolfClubs)
                .Include(p => p.PlayerPracticeSessionAssignments)
                .ThenInclude(p => p.PracticeSession)
                .ThenInclude(p => p.GolfShots).ToListAsync();

            if (id != null)
            {
                PlayerID = id.Value;
                player = allPlayersInfo.Single(i => i.ID == PlayerID);
                PlayerName = player.FullName;
            }

            var golfClubs = _context.GolfClubs.Where(p => p.PlayerID == PlayerID);
            var playerPracticeSessions = player.PlayerPracticeSessionAssignments.Select(s => s.PracticeSession).ToList();
            var practiceSessionAssignments = _context.PlayerPracticeSessionAssignments.Where(p => p.PlayerID == PlayerID);

            var practiceSessions = playerPracticeSessions
                .Join(practiceSessionAssignments, ps => ps.ID, psa => psa.PlayerPracticeSessionAssignmentID, (ps, psa) => new {ps, psa})
                .Join(golfClubs, pspsa => pspsa.psa.GolfClubID, gc => gc.ID, (pspsa, gc) => new {pspsa, gc})
                .Select(x => new PracticeSummaryVM()
                {
                    ClubName = x.gc.Name,
                    PracticeDate = x.pspsa.ps.PracticeDate,
                    Altitude = x.pspsa.ps.Altitude,
                    GolfShots = x.pspsa.ps.GolfShots
                }).ToList();

            PracticeSummaryList = new List<PracticeSummaryVM>();
            //var practiceSummary = new PracticeSummaryVM();
            foreach (var practiceSession in practiceSessions)
            {
                var practiceSummary = new PracticeSummaryVM();
                practiceSummary.ClubName = practiceSession.ClubName;
                practiceSummary.Altitude = practiceSession.Altitude;
                practiceSummary.PracticeDate = practiceSession.PracticeDate;
                practiceSummary.CarryAveYds = CalcAverageYards(practiceSession.GolfShots.Select(gs => gs.CarryYards));
                practiceSummary.TotalAveYds = CalcAverageYards(practiceSession.GolfShots.Select(gs => gs.TotalYards));
                practiceSummary.CarryMedianYds = CalcMedianYards(practiceSession.GolfShots.Select(gs => gs.CarryYards));
                practiceSummary.TotalMedianYds = CalcMedianYards(practiceSession.GolfShots.Select(gs => gs.TotalYards));
                practiceSummary.CarryModeYds = CalcModeYards(practiceSession.GolfShots.Select(gs => gs.CarryYards));
                practiceSummary.TotalModeYds = CalcModeYards(practiceSession.GolfShots.Select(gs => gs.TotalYards));
                practiceSummary.OfflineLeft = CalcAverageYards(practiceSession.GolfShots
                    .Where(gs => gs.OfflineYards <= 0).Select(gs => gs.OfflineYards)) + " Yds Lft";
                practiceSummary.OfflineRight = CalcAverageYards(practiceSession.GolfShots
                    .Where(gs => gs.OfflineYards >= 0).Select(gs => gs.OfflineYards)) + " Yds Rgt";
                practiceSummary.NumberOfShots = practiceSession.GolfShots.Count;

                PracticeSummaryList.Add(practiceSummary);
            }
        }

        public int CalcAverageYards(IEnumerable<int> golfShots)
        {
            return golfShots.Any() ? Convert.ToInt32(Math.Round(golfShots.Average())) : 0;
        }

        public int CalcMedianYards(IEnumerable<int> golfShots)
        {
            int count = golfShots.Count();
            var orderedShots = golfShots.OrderBy(gs => gs);
            float median = orderedShots.ElementAt(count / 2) + orderedShots.ElementAt((count - 1) / 2);
            return Convert.ToInt32(Math.Round(median /= 2));
        }

        public int CalcModeYards(IEnumerable<int> golfShots)
        {
            return golfShots.GroupBy(v => v)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
        }

    }
}