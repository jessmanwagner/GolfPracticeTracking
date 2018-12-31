using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GolfPracticeTracker.Data;
using GolfPracticeTracker.Models;
using GolfPracticeTracker.Models.ViewModels;
using GolfPracticeTracker.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GolfPracticeTracker.Pages.PracticeSessions
{
    public class PracticeSummaryModel : PageModel
    {
        private readonly GolfPracticeTrackerContext _context;

        public PracticeSummaryModel(GolfPracticeTrackerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public IList<SkyTrakCsvFile> SkyTrakCsvFiles { get; private set; }

        public List<PracticeSummaryVM> PracticeSummaryList { get; set; }

        public int PlayerID { get; set; }

        public string PlayerName { get; set; }

        public async Task OnGet(int? id = 1)
        {
            Player player = new Player();

            // Todo: Leverage the navigation properties better?  Instead of pulling from table like lines 46 & 48?
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
                // Todo: Include all below in 'if' or early exit back to page?

                var golfClubs = _context.GolfClubs.Where(p => p.PlayerID == PlayerID);
                var playerPracticeSessions = player.PlayerPracticeSessionAssignments.Select(s => s.PracticeSession).ToList();
                var practiceSessionAssignments = _context.PlayerPracticeSessionAssignments.Where(p => p.PlayerID == PlayerID);

                var practiceSessions = playerPracticeSessions
                    .Join(practiceSessionAssignments, ps => ps.ID, psa => psa.PlayerPracticeSessionAssignmentID, (ps, psa) => new { ps, psa })
                    .Join(golfClubs, pspsa => pspsa.psa.GolfClubID, gc => gc.ID, (pspsa, gc) => new { pspsa, gc })
                    .Select(x => new PracticeSummaryVM()
                    {
                        ClubName = x.gc.Name,
                        PracticeDate = x.pspsa.ps.PracticeDate,
                        //Altitude = x.pspsa.ps.Altitude,
                        GolfShots = x.pspsa.ps.GolfShots
                    }).ToList();

                PracticeSummaryList = new List<PracticeSummaryVM>();
                foreach (var practiceSession in practiceSessions)
                {
                    var practiceSummary = new PracticeSummaryVM();
                    practiceSummary.ClubName = practiceSession.ClubName;
                    //practiceSummary.Altitude = practiceSession.Altitude;
                    practiceSummary.PracticeDate = practiceSession.PracticeDate;
                    practiceSummary.CarryAveYds = CalcAverageYards(practiceSession.GolfShots.Select(gs => gs.CarryYards));
                    practiceSummary.TotalAveYds = CalcAverageYards(practiceSession.GolfShots.Select(gs => gs.TotalYards));
                    practiceSummary.CarryMedianYds = CalcMedianYards(practiceSession.GolfShots.Select(gs => gs.CarryYards));
                    practiceSummary.TotalMedianYds = CalcMedianYards(practiceSession.GolfShots.Select(gs => gs.TotalYards));
                    practiceSummary.CarryModeYds = CalcModeYards(practiceSession.GolfShots.Select(gs => gs.CarryYards));
                    practiceSummary.TotalModeYds = CalcModeYards(practiceSession.GolfShots.Select(gs => gs.TotalYards));
                    practiceSummary.OfflineLeft = CalcAverageYards(practiceSession.GolfShots
                        .Where(gs => gs.OfflineYards <= 0).Select(gs => gs.OfflineYards));
                    practiceSummary.OfflineRight = CalcAverageYards(practiceSession.GolfShots
                        .Where(gs => gs.OfflineYards >= 0).Select(gs => gs.OfflineYards));
                    practiceSummary.NumberOfShots = practiceSession.GolfShots.Count;

                    PracticeSummaryList.Add(practiceSummary);
                }
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var publicScheduleData =
                await FileHelpers.ProcessFormFile(FileUpload.UploadSkyTrakFile, ModelState);

            // Perform a second check to catch ProcessFormFile method
            // violations.
            if (!ModelState.IsValid)
            {
                //SkyTrakCsvFiles = await _context.Schedule.AsNoTracking().ToListAsync();
                return Page();
            }

            var practiceSession = new PracticeSession();
            var playerPracticeSession = new PlayerPracticeSessionAssignment();
            var golfShots = new List<GolfShot>();
            //var schedule = new Schedule()
            //{
            //    PublicSchedule = publicScheduleData,
            //    PublicScheduleSize = FileUpload.UploadPublicSchedule.Length,
            //    Title = FileUpload.Title,
            //    UploadDT = DateTime.UtcNow
            //};

            //_context.Schedule.Add(schedule);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./PracticeSummary");
        }

        // Todo: multiple Enumerations - resolve
        public int CalcAverageYards(IEnumerable<int> golfShots)
        {
            return golfShots.Any() ? Convert.ToInt32(Math.Round(golfShots.Average())) : 0;
        }

        // The Median stat isn't being used, but may be interesting information at some point
        public int CalcMedianYards(IEnumerable<int> golfShots)
        {
            int count = golfShots.Count();
            var orderedShots = golfShots.OrderBy(gs => gs);
            float median = orderedShots.ElementAt(count / 2) + orderedShots.ElementAt((count - 1) / 2);
            return Convert.ToInt32(Math.Round(median /= 2));
        }

        // The Mode stat isn't being used, but may be interesting information at some point
        public int CalcModeYards(IEnumerable<int> golfShots)
        {
            return golfShots.GroupBy(v => v)
                .OrderByDescending(g => g.Count())
                .First()
                .Key;
        }
    }
}