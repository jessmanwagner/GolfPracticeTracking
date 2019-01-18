
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace GolfPracticeTracker.Models
{
    public class GolfShot
    {
        public int ID { get; set; }
        public int PracticeSessionID { get; set; }
        public int ShotNumber { get; set; }
        public double BallMph { get; set; }             //both
        public double ClubMph { get; set; }             //both
        public double LaunchDeg { get; set; }           //both
        public double SideDeg { get; set; }
        public int BackSpinRpm { get; set; }            //both
        public int SideSpinRpm { get; set; }            //both
        public double FlightSeconds { get; set; }
        public int DescentDeg { get; set; }             //both
        public double HeightYards { get; set; }         //both
        public double PtiScore { get; set; }
        public int OfflineYards { get; set; }           //both
        public int CarryYards { get; set; }             //both
        public int RollYards { get; set; }
        public int TotalYards { get; set; }             //both

        //Navigation Properties
        public PracticeSession PracticeSession { get; set; }

    }
}
