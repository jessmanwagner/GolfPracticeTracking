
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GolfPracticeTracker.Models
{
    public class GolfClub
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Loft { get; set; }
        public string Brand { get; set; }
        public string Make { get; set; }
        public bool InBag { get; set; }
        public string Notes { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        public DateTime PurchaseDate { get; set; }
        public int PlayerID { get; set; }
        public int SortOrder { get; set; }
        // Todo: Implement this for a secondary sort order?  Wedges first?  Categorize clubs?
        public string Type { get; set; }    // Wood = 1, Hybrid = 2 Iron =3, Wedge = 4

        //Navigation Properties
        public Player Player { get; set; }
        public PracticeSession PracticeSession { get; set; }
    }
}
