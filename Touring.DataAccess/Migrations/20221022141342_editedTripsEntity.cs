using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Touring.DataAccess.Migrations
{
    public partial class editedTripsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Origin",
                table: "Trip",
                newName: "OriginCountry");

            migrationBuilder.RenameColumn(
                name: "Destination",
                table: "Trip",
                newName: "OriginCity");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalTime",
                table: "Trip",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Trip",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DestinationCity",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DestinationCountry",
                table: "Trip",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalTime",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DestinationCity",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "DestinationCountry",
                table: "Trip");

            migrationBuilder.RenameColumn(
                name: "OriginCountry",
                table: "Trip",
                newName: "Origin");

            migrationBuilder.RenameColumn(
                name: "OriginCity",
                table: "Trip",
                newName: "Destination");
        }
    }
}
