using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Wheight",
                table: "MeasurementEntries",
                newName: "Weight");

            migrationBuilder.RenameColumn(
                name: "RightCalve",
                table: "MeasurementEntries",
                newName: "RightCalf");

            migrationBuilder.RenameColumn(
                name: "LeftThight",
                table: "MeasurementEntries",
                newName: "LeftThigh");

            migrationBuilder.RenameColumn(
                name: "LeftCalve",
                table: "MeasurementEntries",
                newName: "LeftCalf");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "MeasurementEntries",
                newName: "Wheight");

            migrationBuilder.RenameColumn(
                name: "RightCalf",
                table: "MeasurementEntries",
                newName: "RightCalve");

            migrationBuilder.RenameColumn(
                name: "LeftThigh",
                table: "MeasurementEntries",
                newName: "LeftThight");

            migrationBuilder.RenameColumn(
                name: "LeftCalf",
                table: "MeasurementEntries",
                newName: "LeftCalve");
        }
    }
}
