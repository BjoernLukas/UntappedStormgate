using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UntappedAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celestials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    League = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Mmr = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Ties = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celestials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CelestialsPlayerStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recent_mmr_history = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CelestialsPlayerStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Infernals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    League = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Mmr = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Ties = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Infernals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfernalsPlayerStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recent_mmr_history = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfernalsPlayerStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MatchHistoryVisibility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RANKED_1V1 = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchHistoryVisibility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReplayVisibility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RANKED_1V1 = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplayVisibility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vanguard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    League = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Losses = table.Column<int>(type: "int", nullable: false),
                    Mmr = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Ties = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vanguard", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VanguardPlayerStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Recent_mmr_history = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VanguardPlayerStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ranked1v1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanguardId = table.Column<int>(type: "int", nullable: false),
                    InfernalsId = table.Column<int>(type: "int", nullable: false),
                    CelestialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranked1v1", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranked1v1_Celestials_CelestialsId",
                        column: x => x.CelestialsId,
                        principalTable: "Celestials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ranked1v1_Infernals_InfernalsId",
                        column: x => x.InfernalsId,
                        principalTable: "Infernals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ranked1v1_Vanguard_VanguardId",
                        column: x => x.VanguardId,
                        principalTable: "Vanguard",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "All",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VanguardId = table.Column<int>(type: "int", nullable: false),
                    InfernalsId = table.Column<int>(type: "int", nullable: false),
                    CelestialsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_All", x => x.Id);
                    table.ForeignKey(
                        name: "FK_All_CelestialsPlayerStats_CelestialsId",
                        column: x => x.CelestialsId,
                        principalTable: "CelestialsPlayerStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_All_InfernalsPlayerStats_InfernalsId",
                        column: x => x.InfernalsId,
                        principalTable: "InfernalsPlayerStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_All_VanguardPlayerStats_VanguardId",
                        column: x => x.VanguardId,
                        principalTable: "VanguardPlayerStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outcomes_By_Opponent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    player_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    profile_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    wins = table.Column<int>(type: "int", nullable: false),
                    losses = table.Column<int>(type: "int", nullable: false),
                    ties = table.Column<int>(type: "int", nullable: false),
                    CelestialsPlayerStatsId = table.Column<int>(type: "int", nullable: true),
                    InfernalsPlayerStatsId = table.Column<int>(type: "int", nullable: true),
                    VanguardPlayerStatsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outcomes_By_Opponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outcomes_By_Opponent_CelestialsPlayerStats_CelestialsPlayerStatsId",
                        column: x => x.CelestialsPlayerStatsId,
                        principalTable: "CelestialsPlayerStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Outcomes_By_Opponent_InfernalsPlayerStats_InfernalsPlayerStatsId",
                        column: x => x.InfernalsPlayerStatsId,
                        principalTable: "InfernalsPlayerStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Outcomes_By_Opponent_VanguardPlayerStats_VanguardPlayerStatsId",
                        column: x => x.VanguardPlayerStatsId,
                        principalTable: "VanguardPlayerStats",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ranked1v1Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ranks_Ranked1v1_Ranked1v1Id",
                        column: x => x.Ranked1v1Id,
                        principalTable: "Ranked1v1",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CuratedStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuratedStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuratedStats_All_AllId",
                        column: x => x.AllId,
                        principalTable: "All",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profile",
                columns: table => new
                {
                    ProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RanksId = table.Column<int>(type: "int", nullable: false),
                    MatchHistoryVisibilityId = table.Column<int>(type: "int", nullable: false),
                    ReplayVisibilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profile", x => x.ProfileId);
                    table.ForeignKey(
                        name: "FK_Profile_MatchHistoryVisibility_MatchHistoryVisibilityId",
                        column: x => x.MatchHistoryVisibilityId,
                        principalTable: "MatchHistoryVisibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_Ranks_RanksId",
                        column: x => x.RanksId,
                        principalTable: "Ranks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profile_ReplayVisibility_ReplayVisibilityId",
                        column: x => x.ReplayVisibilityId,
                        principalTable: "ReplayVisibility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerSnapshot",
                columns: table => new
                {
                    PlayerSnapshotId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastSnapshot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProfileId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CuratedStatsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSnapshot", x => x.PlayerSnapshotId);
                    table.ForeignKey(
                        name: "FK_PlayerSnapshot_CuratedStats_CuratedStatsId",
                        column: x => x.CuratedStatsId,
                        principalTable: "CuratedStats",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlayerSnapshot_Profile_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profile",
                        principalColumn: "ProfileId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_All_CelestialsId",
                table: "All",
                column: "CelestialsId");

            migrationBuilder.CreateIndex(
                name: "IX_All_InfernalsId",
                table: "All",
                column: "InfernalsId");

            migrationBuilder.CreateIndex(
                name: "IX_All_VanguardId",
                table: "All",
                column: "VanguardId");

            migrationBuilder.CreateIndex(
                name: "IX_CuratedStats_AllId",
                table: "CuratedStats",
                column: "AllId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_By_Opponent_CelestialsPlayerStatsId",
                table: "Outcomes_By_Opponent",
                column: "CelestialsPlayerStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_By_Opponent_InfernalsPlayerStatsId",
                table: "Outcomes_By_Opponent",
                column: "InfernalsPlayerStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_Outcomes_By_Opponent_VanguardPlayerStatsId",
                table: "Outcomes_By_Opponent",
                column: "VanguardPlayerStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSnapshot_CuratedStatsId",
                table: "PlayerSnapshot",
                column: "CuratedStatsId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerSnapshot_ProfileId",
                table: "PlayerSnapshot",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_MatchHistoryVisibilityId",
                table: "Profile",
                column: "MatchHistoryVisibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_RanksId",
                table: "Profile",
                column: "RanksId");

            migrationBuilder.CreateIndex(
                name: "IX_Profile_ReplayVisibilityId",
                table: "Profile",
                column: "ReplayVisibilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranked1v1_CelestialsId",
                table: "Ranked1v1",
                column: "CelestialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranked1v1_InfernalsId",
                table: "Ranked1v1",
                column: "InfernalsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranked1v1_VanguardId",
                table: "Ranked1v1",
                column: "VanguardId");

            migrationBuilder.CreateIndex(
                name: "IX_Ranks_Ranked1v1Id",
                table: "Ranks",
                column: "Ranked1v1Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Outcomes_By_Opponent");

            migrationBuilder.DropTable(
                name: "PlayerSnapshot");

            migrationBuilder.DropTable(
                name: "CuratedStats");

            migrationBuilder.DropTable(
                name: "Profile");

            migrationBuilder.DropTable(
                name: "All");

            migrationBuilder.DropTable(
                name: "MatchHistoryVisibility");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "ReplayVisibility");

            migrationBuilder.DropTable(
                name: "CelestialsPlayerStats");

            migrationBuilder.DropTable(
                name: "InfernalsPlayerStats");

            migrationBuilder.DropTable(
                name: "VanguardPlayerStats");

            migrationBuilder.DropTable(
                name: "Ranked1v1");

            migrationBuilder.DropTable(
                name: "Celestials");

            migrationBuilder.DropTable(
                name: "Infernals");

            migrationBuilder.DropTable(
                name: "Vanguard");
        }
    }
}
