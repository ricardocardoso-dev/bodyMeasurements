using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class NewMeasurementEntryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MeasurementEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Height = table.Column<decimal>(type: "TEXT", nullable: false),
                    Wheight = table.Column<decimal>(type: "TEXT", nullable: false),
                    Shoulders = table.Column<decimal>(type: "TEXT", nullable: false),
                    Chest = table.Column<decimal>(type: "TEXT", nullable: false),
                    Waist = table.Column<decimal>(type: "TEXT", nullable: false),
                    Hip = table.Column<decimal>(type: "TEXT", nullable: false),
                    RightArm = table.Column<decimal>(type: "TEXT", nullable: false),
                    LeftArm = table.Column<decimal>(type: "TEXT", nullable: false),
                    RightForearm = table.Column<decimal>(type: "TEXT", nullable: false),
                    LeftForearm = table.Column<decimal>(type: "TEXT", nullable: false),
                    RightThigh = table.Column<decimal>(type: "TEXT", nullable: false),
                    LeftThight = table.Column<decimal>(type: "TEXT", nullable: false),
                    RightCalve = table.Column<decimal>(type: "TEXT", nullable: false),
                    LeftCalve = table.Column<decimal>(type: "TEXT", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserNameCreator = table.Column<string>(type: "TEXT", nullable: true),
                    UserNameLastChange = table.Column<string>(type: "TEXT", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastChangeDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasurementEntries_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementEntries_PersonId",
                table: "MeasurementEntries",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MeasurementEntries");
        }
    }
}
