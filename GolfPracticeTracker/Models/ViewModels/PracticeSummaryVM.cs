using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GolfPracticeTracker.Models.ViewModels
{
    public class PracticeSummaryVM
    {
        //public string PlayerName { get; set; }
        public string ClubName { get; set; }
        public int Altitude { get; set; }
        public int CarryAveYds { get; set; }
        public int CarryMedianYds { get; set; }
        public int CarryModeYds { get; set; }
        public int TotalAveYds { get; set; }
        public int TotalMedianYds { get; set; }
        public int TotalModeYds { get; set; }
        public int OfflineLeft { get; set; }
        public int OfflineRight { get; set; }
        public int NumberOfShots { get; set; }
        public int NumberOfShotsLeft { get; set; }
        public int NumberOfShotsRight { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}")]
        public DateTime PracticeDate { get; set; }
        public ICollection<GolfShot> GolfShots { get; set; }
    }
}
