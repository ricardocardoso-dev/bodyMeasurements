using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class PersonEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RightArm",
                table: "MeasurementEntries",
                newName: "RelaxedRightArm");

            migrationBuilder.RenameColumn(
                name: "LeftArm",
                table: "MeasurementEntries",
                newName: "RelaxedLeftArm");

            migrationBuilder.AddColumn<int>(
                name: "PersonType",
                table: "Persons",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ContractedLeftArm",
                table: "MeasurementEntries",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ContractedRightArm",
                table: "MeasurementEntries",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonType",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "ContractedLeftArm",
                table: "MeasurementEntries");

            migrationBuilder.DropColumn(
                name: "ContractedRightArm",
                table: "MeasurementEntries");

            migrationBuilder.RenameColumn(
                name: "RelaxedRightArm",
                table: "MeasurementEntries",
                newName: "RightArm");

            migrationBuilder.RenameColumn(
                name: "RelaxedLeftArm",
                table: "MeasurementEntries",
                newName: "LeftArm");
        }
    }
}
