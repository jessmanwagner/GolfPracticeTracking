using System;
using System.Linq;
using GolfPracticeTracker.Models;

namespace GolfPracticeTracker.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GolfPracticeTrackerContext context)
        {
            // Look for any existing Players
            if (context.Players.Any())
            {
                return; // Database has been added
            }

            // Load test data into arrays rather than List<T> collections to optimize performance
            var players = new Player[]
            {
                new Player {FirstName = "Jesse", LastName = "Wagner"},
                new Player {FirstName = "Tiger", LastName = "Woods"},
                new Player {FirstName = "Lily", LastName = "Wagner"},
                new Player {FirstName = "Jenna", LastName = "Wagner"},
                new Player {FirstName = "Verl", LastName = "Wagner"}
            };

            foreach (var player in players)
            {
                context.Add(player);
            }
            context.SaveChanges();

            var golfClubs = new GolfClub[]
            {
                new GolfClub //1
                {
                    Brand = "Ping",
                    Make = "G25",
                    Loft = 9,
                    Name = "Driver",
                    PurchaseDate = DateTime.Parse("2014-10-23"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub
                {
                    Brand = "Ping",
                    Make = "G25",
                    Loft = 18,
                    Name = "4 Wood",
                    PurchaseDate = DateTime.Parse("2014-10-23"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub //3
                {
                    Brand = "TaylorMade",
                    Make = "P790",
                    Loft = 23,
                    Name = "4 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub
                {
                    Brand = "TaylorMade",
                    Make = "P790",
                    Loft = 23,
                    Name = "5 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub //5
                {
                    Brand = "TaylorMade",
                    Make = "P790",
                    Loft = 23,
                    Name = "6 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub
                {
                    Brand = "TaylorMade",
                    Make = "P790",
                    Loft = 23,
                    Name = "7 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub //7
                {
                    Brand = "TaylorMade",
                    Make = "P790",
                    Loft = 23,
                    Name = "8 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub //8
                {
                    Brand = "TaylorMade",
                    Make = "P790",
                    Loft = 23,
                    Name = "9 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub
                {
                    Brand = "TaylorMade",
                    Make = "P790",
                    Loft = 23,
                    Name = "P Wedge",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub //10
                {
                    Brand = "TaylorMade",
                    Make = "P790",
                    Loft = 23,
                    Name = "A Wedge",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub //11
                {
                    Brand = "Callaway",
                    Make = "MackDaddy",
                    Loft = 52,
                    Name = "52 Degree",
                    PurchaseDate = DateTime.Parse("2018-11-3"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub //12
                {
                    Brand = "Callaway",
                    Make = "MackDaddy",
                    Loft = 56,
                    Name = "56 Degree",
                    PurchaseDate = DateTime.Parse("2018-11-3"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub //13
                {
                    Brand = "Callaway",
                    Make = "MackDaddy",
                    Loft = 60,
                    Name = "60 Degree",
                    PurchaseDate = DateTime.Parse("2018-11-3"),
                    InBag = true,
                    PlayerID = 1
                },
                new GolfClub //14 //wedge not in bag
                {
                    Brand = "Cleveland",
                    Make = "Xxx",
                    Loft = 54,
                    Name = "54 Degree",
                    PurchaseDate = DateTime.Parse("2016-11-3"),
                    InBag = false,
                    PlayerID = 1
                },
                new GolfClub //15
                {
                    Brand = "Cleveland",
                    Make = "Xxx",
                    Loft = 58,
                    Name = "58 Degree",
                    PurchaseDate = DateTime.Parse("2016-11-3"),
                    InBag = false,
                    PlayerID = 1
                },
                new GolfClub //Row 16 //Club 1
                {
                    Brand = "Ping",
                    Make = "G25",
                    Loft = 9,
                    Name = "Driver",
                    PurchaseDate = DateTime.Parse("2014-10-23"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 17 //Club 2
                {
                    Brand = "Ping",
                    Make = "G25",
                    Loft = 18,
                    Name = "4 Wood",
                    PurchaseDate = DateTime.Parse("2014-10-23"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 18 //Club 3
                {
                    Brand = "Ping",
                    Make = "P790",
                    Loft = 23,
                    Name = "4 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 19 //Club 4
                {
                    Brand = "Ping",
                    Make = "P790",
                    Loft = 23,
                    Name = "5 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 20 //Club 5
                {
                    Brand = "Ping",
                    Make = "P790",
                    Loft = 23,
                    Name = "6 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 21 Club 6
                {
                    Brand = "Ping",
                    Make = "P790",
                    Loft = 23,
                    Name = "7 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 22 Club 7
                {
                    Brand = "Ping",
                    Make = "P790",
                    Loft = 23,
                    Name = "8 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 23 Club 8
                {
                    Brand = "Ping",
                    Make = "P790",
                    Loft = 23,
                    Name = "9 Iron",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 24 Club 9
                {
                    Brand = "Ping",
                    Make = "P790",
                    Loft = 23,
                    Name = "P Wedge",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 25 Club 10 
                {
                    Brand = "Ping",
                    Make = "P790",
                    Loft = 23,
                    Name = "A Wedge",
                    PurchaseDate = DateTime.Parse("2018-10-23"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 26 Club 11
                {
                    Brand = "Ping",
                    Make = "MackDaddy",
                    Loft = 52,
                    Name = "52 Degree",
                    PurchaseDate = DateTime.Parse("2018-11-3"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 27 Club 12
                {
                    Brand = "Ping",
                    Make = "MackDaddy",
                    Loft = 56,
                    Name = "56 Degree",
                    PurchaseDate = DateTime.Parse("2018-11-3"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 28 Club 13
                {
                    Brand = "Ping",
                    Make = "MackDaddy",
                    Loft = 60,
                    Name = "60 Degree",
                    PurchaseDate = DateTime.Parse("2018-11-3"),
                    InBag = true,
                    PlayerID = 2
                },
                new GolfClub //Row 29 Club 14 - wedge not in bag
                {
                    Brand = "Ping",
                    Make = "Xxx",
                    Loft = 54,
                    Name = "54 Degree",
                    PurchaseDate = DateTime.Parse("2016-11-3"),
                    InBag = false,
                    PlayerID = 2
                },
                new GolfClub //Row 30 Club 15
                {
                    Brand = "Ping",
                    Make = "Xxx",
                    Loft = 58,
                    Name = "58 Degree",
                    PurchaseDate = DateTime.Parse("2016-11-3"),
                    InBag = false,
                    PlayerID = 2
                }

            };
            foreach (var club in golfClubs)
            {
                context.Add(club);
            }
            context.SaveChanges();

            var practiceSessions = new PracticeSession[]
            {
                new PracticeSession // 1
                {
                    Altitude = 5280,
                    //GolfClubID = 7,
                    //PlayerID = 1,
                    PracticeDate = DateTime.Parse("2018-2-8")
                },
                new PracticeSession //2
                {
                    Altitude = 5280,
                    //GolfClubID = 10,
                    //PlayerID = 1,
                    PracticeDate = DateTime.Parse("2018-2-8")
                },
                new PracticeSession //3
                {
                    Altitude = 5280,
                    //GolfClubID = 10,
                    //PlayerID = 1,
                    PracticeDate = DateTime.Parse("2018-2-10")
                },
                new PracticeSession //4
                {
                    Altitude = 5280,
                    //GolfClubID = 10,
                    //PlayerID = 1,
                    PracticeDate = DateTime.Parse("2018-2-12")
                },
                new PracticeSession //5
                {
                    Altitude = 5280,
                    //GolfClubID = 6,
                    //PlayerID = 1,
                    PracticeDate = DateTime.Parse("2018-2-18")
                },
                new PracticeSession //6
                {
                    Altitude = 5280,
                    //GolfClubID = 10,
                    //PlayerID = 2,
                    PracticeDate = DateTime.Parse("2018-2-10")
                },
                new PracticeSession //7
                {
                    Altitude = 5280,
                    //GolfClubID = 10,
                    //PlayerID = 2,
                    PracticeDate = DateTime.Parse("2018-2-12")
                },
                new PracticeSession //8
                {
                    Altitude = 5280,
                    //GolfClubID = 6,
                    //PlayerID = 2,
                    PracticeDate = DateTime.Parse("2018-2-18")
                }
            };
            foreach (var practiceSession in practiceSessions)
            {
                context.Add(practiceSession);
            }
            context.SaveChanges();

            var playerPracticeSessionAssignments = new PlayerPracticeSessionAssignment[]
            {
                new PlayerPracticeSessionAssignment()
                {
                    GolfClubID = 7,
                    PlayerID = 1,
                    PracticeSessionID = 1
                },
                new PlayerPracticeSessionAssignment()
                {
                    GolfClubID = 10,
                    PlayerID = 1,
                    PracticeSessionID = 2
                },
                new PlayerPracticeSessionAssignment()
                {
                    GolfClubID = 10,
                    PlayerID = 1,
                    PracticeSessionID = 3
                },
                new PlayerPracticeSessionAssignment()
                {
                    GolfClubID = 10,
                    PlayerID = 1,
                    PracticeSessionID = 4
                },
                new PlayerPracticeSessionAssignment()
                {
                    GolfClubID = 6,
                    PlayerID = 1,
                    PracticeSessionID = 5
                },
                new PlayerPracticeSessionAssignment()
                {
                    GolfClubID = 10,
                    PlayerID = 2,
                    PracticeSessionID = 6
                },
                new PlayerPracticeSessionAssignment()
                {
                    GolfClubID = 10,
                    PlayerID = 2,
                    PracticeSessionID = 7
                },
                new PlayerPracticeSessionAssignment()
                {
                    GolfClubID = 6,
                    PlayerID = 2,
                    PracticeSessionID = 8
                },
            };
            foreach (var playerPracticeSessionAssignment in playerPracticeSessionAssignments)
            {
                context.Add(playerPracticeSessionAssignment);
            }
            context.SaveChanges();

            var golfShots = new GolfShot[]
            {
                new GolfShot //8 Iron
                {
                    PracticeSessionID = 1,
                    ShotNumber = 1,
                    BallMph = 100,
                    ClubMph = 75,
                    LaunchDegree = 18.4,
                    SideDegree = -0.7,
                    BackSpinRpm = 4842,
                    SideSpinRpm = -563,
                    FlightSeconds = 4.9,
                    DescentDegree = 36,
                    HeightYards = 19,
                    PtiScore = 1.34,
                    OfflineYards = -11,
                    CarryYards = 138,
                    RollYards = 14,
                    TotalYards = 152
                },
                new GolfShot //8 Iron
                {
                    PracticeSessionID = 1,
                    ShotNumber = 2,
                    BallMph = 100,
                    ClubMph = 75,
                    LaunchDegree = 18.4,
                    SideDegree = -0.7,
                    BackSpinRpm = 4842,
                    SideSpinRpm = -563,
                    FlightSeconds = 4.9,
                    DescentDegree = 36,
                    HeightYards = 19,
                    PtiScore = 1.34,
                    OfflineYards = -11,
                    CarryYards = 138,
                    RollYards = 14,
                    TotalYards = 152
                },
                new GolfShot //8 Iron
                {
                    PracticeSessionID = 1,
                    ShotNumber = 3,
                    BallMph = 103,
                    ClubMph = 76,
                    LaunchDegree = 19.4,
                    SideDegree = -0.4,
                    BackSpinRpm = 4642,
                    SideSpinRpm = -663,
                    FlightSeconds = 4.5,
                    DescentDegree = 36,
                    HeightYards = 19,
                    PtiScore = 1.34,
                    OfflineYards = -8,
                    CarryYards = 136,
                    RollYards = 14,
                    TotalYards = 150
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 2,
                    ShotNumber = 1,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 2,
                    ShotNumber = 2,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 2,
                    ShotNumber = 3,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 2,
                    ShotNumber = 4,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 3,
                    ShotNumber = 1,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 3,
                    ShotNumber = 2,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 3,
                    ShotNumber = 3,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 3,
                    ShotNumber = 4,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 3,
                    ShotNumber = 5,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 3,
                    ShotNumber = 6,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 3,
                    ShotNumber = 7,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 3,
                    ShotNumber = 8,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                //////  Practice session 4
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 1,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 2,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 3,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 4,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 5,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 6,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 7,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 8,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 9,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 10,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 11,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 4,
                    ShotNumber = 12,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                // Practice session 4
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 5,
                    ShotNumber = 1,
                    BallMph = 106.9,
                    ClubMph = 78.7,
                    LaunchDegree = 20.1,
                    SideDegree = 0,
                    BackSpinRpm = 4259,
                    SideSpinRpm = 832,
                    FlightSeconds = 0,
                    DescentDegree = 44,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -3,
                    CarryYards = 161,
                    RollYards = 18,
                    TotalYards = 179
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 5,
                    ShotNumber = 2,
                    BallMph = 104.9,
                    ClubMph = 76.7,
                    LaunchDegree = 21.1,
                    SideDegree = 0,
                    BackSpinRpm = 4059,
                    SideSpinRpm = 932,
                    FlightSeconds = 0,
                    DescentDegree = 42,
                    HeightYards = 28,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 158,
                    RollYards = 18,
                    TotalYards = 176
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 5,
                    ShotNumber = 3,
                    BallMph = 108.9,
                    ClubMph = 79.7,
                    LaunchDegree = 23.1,
                    SideDegree = 0,
                    BackSpinRpm = 4659,
                    SideSpinRpm = 872,
                    FlightSeconds = 0,
                    DescentDegree = 40,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -5,
                    CarryYards = 168,
                    RollYards = 18,
                    TotalYards = 186
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 5,
                    ShotNumber = 4,
                    BallMph = 106.9,
                    ClubMph = 78.7,
                    LaunchDegree = 20.1,
                    SideDegree = 0,
                    BackSpinRpm = 4259,
                    SideSpinRpm = 832,
                    FlightSeconds = 0,
                    DescentDegree = 44,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -3,
                    CarryYards = 161,
                    RollYards = 18,
                    TotalYards = 179
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 5,
                    ShotNumber = 5,
                    BallMph = 104.9,
                    ClubMph = 76.7,
                    LaunchDegree = 21.1,
                    SideDegree = 0,
                    BackSpinRpm = 4059,
                    SideSpinRpm = 932,
                    FlightSeconds = 0,
                    DescentDegree = 42,
                    HeightYards = 28,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 158,
                    RollYards = 18,
                    TotalYards = 176
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 5,
                    ShotNumber = 6,
                    BallMph = 108.9,
                    ClubMph = 79.7,
                    LaunchDegree = 23.1,
                    SideDegree = 0,
                    BackSpinRpm = 4659,
                    SideSpinRpm = 872,
                    FlightSeconds = 0,
                    DescentDegree = 40,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -5,
                    CarryYards = 168,
                    RollYards = 18,
                    TotalYards = 186
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 6,
                    ShotNumber = 1,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 6,
                    ShotNumber = 2,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 6,
                    ShotNumber = 3,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 6,
                    ShotNumber = 4,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 6,
                    ShotNumber = 5,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 6,
                    ShotNumber = 6,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 7,
                    ShotNumber = 1,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 7,
                    ShotNumber = 2,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 7,
                    ShotNumber = 3,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 7,
                    ShotNumber = 4,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 7,
                    ShotNumber = 5,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 7,
                    ShotNumber = 6,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 7,
                    ShotNumber = 7,
                    BallMph = 81.2,
                    ClubMph = 59.7,
                    LaunchDegree = 31.9,
                    SideDegree = 0,
                    BackSpinRpm = 6779,
                    SideSpinRpm = 1485,
                    FlightSeconds = 0,
                    DescentDegree = 51,
                    HeightYards = 27,
                    PtiScore = 1.34,
                    OfflineYards = -4,
                    CarryYards = 104,
                    RollYards = 8,
                    TotalYards = 112
                },
                new GolfShot // A Iron
                {
                    PracticeSessionID = 7,
                    ShotNumber = 8,
                    BallMph = 83.2,
                    ClubMph = 61.7,
                    LaunchDegree = 33.9,
                    SideDegree = 0,
                    BackSpinRpm = 6879,
                    SideSpinRpm = 1685,
                    FlightSeconds = 0,
                    DescentDegree = 53,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 102,
                    RollYards = 13,
                    TotalYards = 115
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 1,
                    BallMph = 106.9,
                    ClubMph = 78.7,
                    LaunchDegree = 20.1,
                    SideDegree = 0,
                    BackSpinRpm = 4259,
                    SideSpinRpm = 832,
                    FlightSeconds = 0,
                    DescentDegree = 44,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -3,
                    CarryYards = 161,
                    RollYards = 18,
                    TotalYards = 179
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 2,
                    BallMph = 104.9,
                    ClubMph = 76.7,
                    LaunchDegree = 21.1,
                    SideDegree = 0,
                    BackSpinRpm = 4059,
                    SideSpinRpm = 932,
                    FlightSeconds = 0,
                    DescentDegree = 42,
                    HeightYards = 28,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 158,
                    RollYards = 18,
                    TotalYards = 176
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 3,
                    BallMph = 108.9,
                    ClubMph = 79.7,
                    LaunchDegree = 23.1,
                    SideDegree = 0,
                    BackSpinRpm = 4659,
                    SideSpinRpm = 872,
                    FlightSeconds = 0,
                    DescentDegree = 40,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -5,
                    CarryYards = 168,
                    RollYards = 18,
                    TotalYards = 186
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 4,
                    BallMph = 106.9,
                    ClubMph = 78.7,
                    LaunchDegree = 20.1,
                    SideDegree = 0,
                    BackSpinRpm = 4259,
                    SideSpinRpm = 832,
                    FlightSeconds = 0,
                    DescentDegree = 44,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -3,
                    CarryYards = 161,
                    RollYards = 18,
                    TotalYards = 179
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 5,
                    BallMph = 104.9,
                    ClubMph = 76.7,
                    LaunchDegree = 21.1,
                    SideDegree = 0,
                    BackSpinRpm = 4059,
                    SideSpinRpm = 932,
                    FlightSeconds = 0,
                    DescentDegree = 42,
                    HeightYards = 28,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 158,
                    RollYards = 18,
                    TotalYards = 176
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 6,
                    BallMph = 108.9,
                    ClubMph = 79.7,
                    LaunchDegree = 23.1,
                    SideDegree = 0,
                    BackSpinRpm = 4659,
                    SideSpinRpm = 872,
                    FlightSeconds = 0,
                    DescentDegree = 40,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -5,
                    CarryYards = 168,
                    RollYards = 18,
                    TotalYards = 186
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 7,
                    BallMph = 106.9,
                    ClubMph = 78.7,
                    LaunchDegree = 20.1,
                    SideDegree = 0,
                    BackSpinRpm = 4259,
                    SideSpinRpm = 832,
                    FlightSeconds = 0,
                    DescentDegree = 44,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -3,
                    CarryYards = 161,
                    RollYards = 18,
                    TotalYards = 179
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 8,
                    BallMph = 104.9,
                    ClubMph = 76.7,
                    LaunchDegree = 21.1,
                    SideDegree = 0,
                    BackSpinRpm = 4059,
                    SideSpinRpm = 932,
                    FlightSeconds = 0,
                    DescentDegree = 42,
                    HeightYards = 28,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 158,
                    RollYards = 18,
                    TotalYards = 176
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 9,
                    BallMph = 108.9,
                    ClubMph = 79.7,
                    LaunchDegree = 23.1,
                    SideDegree = 0,
                    BackSpinRpm = 4659,
                    SideSpinRpm = 872,
                    FlightSeconds = 0,
                    DescentDegree = 40,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -5,
                    CarryYards = 168,
                    RollYards = 18,
                    TotalYards = 186
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 10,
                    BallMph = 106.9,
                    ClubMph = 78.7,
                    LaunchDegree = 20.1,
                    SideDegree = 0,
                    BackSpinRpm = 4259,
                    SideSpinRpm = 832,
                    FlightSeconds = 0,
                    DescentDegree = 44,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -3,
                    CarryYards = 161,
                    RollYards = 18,
                    TotalYards = 179
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 11,
                    BallMph = 104.9,
                    ClubMph = 76.7,
                    LaunchDegree = 21.1,
                    SideDegree = 0,
                    BackSpinRpm = 4059,
                    SideSpinRpm = 932,
                    FlightSeconds = 0,
                    DescentDegree = 42,
                    HeightYards = 28,
                    PtiScore = 1.34,
                    OfflineYards = -2,
                    CarryYards = 158,
                    RollYards = 18,
                    TotalYards = 176
                },
                new GolfShot // 7 Iron
                {
                    PracticeSessionID = 8,
                    ShotNumber = 12,
                    BallMph = 108.9,
                    ClubMph = 79.7,
                    LaunchDegree = 23.1,
                    SideDegree = 0,
                    BackSpinRpm = 4659,
                    SideSpinRpm = 872,
                    FlightSeconds = 0,
                    DescentDegree = 40,
                    HeightYards = 29,
                    PtiScore = 1.34,
                    OfflineYards = -5,
                    CarryYards = 168,
                    RollYards = 18,
                    TotalYards = 186
                }
            };
            foreach (var golfShot in golfShots)
            {
                context.Add(golfShot);
            }
            context.SaveChanges();
        }
    }
}
