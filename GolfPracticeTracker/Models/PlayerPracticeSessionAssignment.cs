
namespace GolfPracticeTracker.Models
{
    public class PlayerPracticeSessionAssignment
    {
        public int PlayerPracticeSessionAssignmentID { get; set; }
        public int PlayerID { get; set; }
        public int GolfClubID { get; set; }
        public int PracticeSessionID { get; set; }

        //Navigation Properties
        public Player Player { get; set; }
        public PracticeSession PracticeSession { get; set; }

    }
}
