
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace GolfPracticeTracker.Models
{
    public class GolfShot
    {
        public int ID { get; set; }
        public int PracticeSessionID { get; set; }
        public int ShotNumber { get; set; }
        public double BallMph { get; set; }
        public double ClubMph { get; set; }
        public double LaunchDeg { get; set; }
        public double SideDeg { get; set; }
        public int BackSpinRpm { get; set; }
        public int SideSpinRpm { get; set; }
        public double FlightSeconds { get; set; }
        public int DescentDeg { get; set; }
        public double HeightYards { get; set; }
        public double PtiScore { get; set; }
        public int OfflineYards { get; set; }
        public int CarryYards { get; set; }
        public int RollYards { get; set; }
        public int TotalYards { get; set; }

        //Navigation Properties
        public PracticeSession PracticeSession { get; set; }

    }
}
