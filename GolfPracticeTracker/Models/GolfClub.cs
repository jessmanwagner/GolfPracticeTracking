
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

        //Navigation Properties
        public Player Player { get; set; }
        public PracticeSession PracticeSession { get; set; }
    }
}
