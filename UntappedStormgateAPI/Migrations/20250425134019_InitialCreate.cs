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
                name: "PlayerSnapshot",
                columns: table => new
                {
                    ProfileId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastSnapshot = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InfoRichness = table.Column<int>(type: "int", nullable: false),
                    PlayerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatchHistoryVisibility = table.Column<bool>(type: "bit", nullable: true),
                    ReplayVisibility = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerSnapshot", x => x.ProfileId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerSnapshot");
        }
    }
}
