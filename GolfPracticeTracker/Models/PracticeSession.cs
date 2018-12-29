using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.NetworkInformation;

namespace GolfPracticeTracker.Models
{
    public class PracticeSession
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        //The DataType attribute emits HTML 5 data- (pronounced data dash) attributes that HTML 5 browsers consume. The DataType attributes don't provide validation.
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime PracticeDate { get; set; }

        public int Altitude { get; set; }

        //Navigation Properties
        public ICollection<PlayerPracticeSessionAssignment> PlayerPracticeSessionAssignments { get; set; }
        public ICollection<GolfShot> GolfShots { get; set; }
    }
}
