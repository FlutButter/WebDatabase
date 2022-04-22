using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fishfirm.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Displacement = table.Column<int>(type: "int", nullable: false),
                    DateConstruct = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fish",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kind = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fish", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fishermen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fishermen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FishPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FishermanTeam",
                columns: table => new
                {
                    FishermenId = table.Column<int>(type: "int", nullable: false),
                    TeamsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishermanTeam", x => new { x.FishermenId, x.TeamsId });
                    table.ForeignKey(
                        name: "FK_FishermanTeam_Fishermen_FishermenId",
                        column: x => x.FishermenId,
                        principalTable: "Fishermen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FishermanTeam_Teams_TeamsId",
                        column: x => x.TeamsId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FishingOuts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRelease = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateReturn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BoatId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishingOuts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FishingOuts_Boats_BoatId",
                        column: x => x.BoatId,
                        principalTable: "Boats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FishingOuts_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VisitFishPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Quality = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    FishingOutId = table.Column<int>(type: "int", nullable: false),
                    FishPlaceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitFishPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VisitFishPlaces_FishingOuts_FishingOutId",
                        column: x => x.FishingOutId,
                        principalTable: "FishingOuts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VisitFishPlaces_FishPlaces_FishPlaceId",
                        column: x => x.FishPlaceId,
                        principalTable: "FishPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Weight = table.Column<int>(type: "int", maxLength: 100, nullable: false),
                    VisitFishPlaceId = table.Column<int>(type: "int", nullable: false),
                    FishId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Catches_Fish_FishId",
                        column: x => x.FishId,
                        principalTable: "Fish",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Catches_VisitFishPlaces_VisitFishPlaceId",
                        column: x => x.VisitFishPlaceId,
                        principalTable: "VisitFishPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Catches_FishId",
                table: "Catches",
                column: "FishId");

            migrationBuilder.CreateIndex(
                name: "IX_Catches_VisitFishPlaceId",
                table: "Catches",
                column: "VisitFishPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_FishermanTeam_TeamsId",
                table: "FishermanTeam",
                column: "TeamsId");

            migrationBuilder.CreateIndex(
                name: "IX_FishingOuts_BoatId",
                table: "FishingOuts",
                column: "BoatId");

            migrationBuilder.CreateIndex(
                name: "IX_FishingOuts_TeamId",
                table: "FishingOuts",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitFishPlaces_FishingOutId",
                table: "VisitFishPlaces",
                column: "FishingOutId");

            migrationBuilder.CreateIndex(
                name: "IX_VisitFishPlaces_FishPlaceId",
                table: "VisitFishPlaces",
                column: "FishPlaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Catches");

            migrationBuilder.DropTable(
                name: "FishermanTeam");

            migrationBuilder.DropTable(
                name: "Fish");

            migrationBuilder.DropTable(
                name: "VisitFishPlaces");

            migrationBuilder.DropTable(
                name: "Fishermen");

            migrationBuilder.DropTable(
                name: "FishingOuts");

            migrationBuilder.DropTable(
                name: "FishPlaces");

            migrationBuilder.DropTable(
                name: "Boats");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
