using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSDU.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddFacilityMeasurementUnits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DEPTH_UOM",
                table: "FACILITY",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ELEVATION_UOM",
                table: "FACILITY",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FACILITY_DIAMETER_UOM",
                table: "FACILITY",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DEPTH_UOM",
                table: "FACILITY");

            migrationBuilder.DropColumn(
                name: "ELEVATION_UOM",
                table: "FACILITY");

            migrationBuilder.DropColumn(
                name: "FACILITY_DIAMETER_UOM",
                table: "FACILITY");
        }
    }
}
