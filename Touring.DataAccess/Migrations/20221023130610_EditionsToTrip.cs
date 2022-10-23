using Microsoft.EntityFrameworkCore.Migrations;

namespace Touring.DataAccess.Migrations
{
    public partial class EditionsToTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusNumber",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "Trip");

            migrationBuilder.AddColumn<string>(
                name: "VehicleNumber",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VehicleNumber",
                table: "Trip");

            migrationBuilder.AddColumn<string>(
                name: "BusNumber",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FlightNumber",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
