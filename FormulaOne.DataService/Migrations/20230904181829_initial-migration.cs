using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FormulaOne.DataService.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    firstName = table.Column<string>(type: "TEXT", nullable: false),
                    lastName = table.Column<string>(type: "TEXT", nullable: false),
                    dateofbirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    driverNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    createdDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "achievements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    racewins = table.Column<int>(type: "INTEGER", nullable: false),
                    fastestLap = table.Column<int>(type: "INTEGER", nullable: false),
                    champions = table.Column<int>(type: "INTEGER", nullable: false),
                    poleposition = table.Column<int>(type: "INTEGER", nullable: false),
                    DriverId = table.Column<Guid>(type: "TEXT", nullable: false),
                    createdDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    updatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achivement_Driver",
                        column: x => x.DriverId,
                        principalTable: "drivers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_achievements_DriverId",
                table: "achievements",
                column: "DriverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "achievements");

            migrationBuilder.DropTable(
                name: "drivers");
        }
    }
}
