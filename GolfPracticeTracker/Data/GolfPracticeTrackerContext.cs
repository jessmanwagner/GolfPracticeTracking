
using GolfPracticeTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace GolfPracticeTracker.Data
{
    public class GolfPracticeTrackerContext : DbContext
    {
        public GolfPracticeTrackerContext (DbContextOptions<GolfPracticeTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<GolfClub> GolfClubs { get; set; }
        public DbSet<PracticeSession> PracticeSessions { get; set; }
        public DbSet<GolfShot> GolfShots { get; set; }
        public DbSet<PlayerPracticeSessionAssignment> PlayerPracticeSessionAssignments { get; set; }
}
}
