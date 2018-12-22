using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GolfPracticeTracker.Models
{
    public class Player
    {
        public int ID { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        [StringLength(20, ErrorMessage = "First name cannot be longer than 20 characters.")]
        [Column("FirstName")]  // maps the name to the database if it happens to be different -> if it was TheFirstName in app, names column FirstName in database
        public string FirstName { get; set; }

        public string FullName => FirstName + " " + LastName;

        //Navigation Properties
        public ICollection<PlayerPracticeSessionAssignment> PlayerPracticeSessionAssignments { get; set; }
        public ICollection<GolfClub> GolfClubs { get; set; }

    }
}
