using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GolfPracticeTracker.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LastName = table.Column<string>(maxLength: 20, nullable: true),
                    FirstName = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PracticeSessions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    PracticeDate = table.Column<DateTime>(nullable: false),
                    Altitude = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PracticeSessions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "GolfClubs",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Loft = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Make = table.Column<string>(nullable: true),
                    InBag = table.Column<bool>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(nullable: false),
                    PlayerID = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    PracticeSessionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GolfClubs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GolfClubs_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GolfClubs_PracticeSessions_PracticeSessionID",
                        column: x => x.PracticeSessionID,
                        principalTable: "PracticeSessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GolfShots",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PracticeSessionID = table.Column<int>(nullable: false),
                    ShotNumber = table.Column<int>(nullable: false),
                    BallMph = table.Column<double>(nullable: false),
                    ClubMph = table.Column<double>(nullable: false),
                    LaunchDeg = table.Column<double>(nullable: false),
                    SideDeg = table.Column<double>(nullable: false),
                    BackSpinRpm = table.Column<int>(nullable: false),
                    SideSpinRpm = table.Column<int>(nullable: false),
                    FlightSeconds = table.Column<double>(nullable: false),
                    DescentDeg = table.Column<int>(nullable: false),
                    HeightYards = table.Column<double>(nullable: false),
                    PtiScore = table.Column<double>(nullable: false),
                    OfflineYards = table.Column<int>(nullable: false),
                    CarryYards = table.Column<int>(nullable: false),
                    RollYards = table.Column<int>(nullable: false),
                    TotalYards = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GolfShots", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GolfShots_PracticeSessions_PracticeSessionID",
                        column: x => x.PracticeSessionID,
                        principalTable: "PracticeSessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPracticeSessionAssignments",
                columns: table => new
                {
                    PlayerPracticeSessionAssignmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlayerID = table.Column<int>(nullable: false),
                    GolfClubID = table.Column<int>(nullable: false),
                    PracticeSessionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPracticeSessionAssignments", x => x.PlayerPracticeSessionAssignmentID);
                    table.ForeignKey(
                        name: "FK_PlayerPracticeSessionAssignments_Players_PlayerID",
                        column: x => x.PlayerID,
                        principalTable: "Players",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerPracticeSessionAssignments_PracticeSessions_PracticeSessionID",
                        column: x => x.PracticeSessionID,
                        principalTable: "PracticeSessions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GolfClubs_PlayerID",
                table: "GolfClubs",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_GolfClubs_PracticeSessionID",
                table: "GolfClubs",
                column: "PracticeSessionID");

            migrationBuilder.CreateIndex(
                name: "IX_GolfShots_PracticeSessionID",
                table: "GolfShots",
                column: "PracticeSessionID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPracticeSessionAssignments_PlayerID",
                table: "PlayerPracticeSessionAssignments",
                column: "PlayerID");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPracticeSessionAssignments_PracticeSessionID",
                table: "PlayerPracticeSessionAssignments",
                column: "PracticeSessionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GolfClubs");

            migrationBuilder.DropTable(
                name: "GolfShots");

            migrationBuilder.DropTable(
                name: "PlayerPracticeSessionAssignments");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "PracticeSessions");
        }
    }
}
