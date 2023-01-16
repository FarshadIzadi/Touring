using Microsoft.EntityFrameworkCore.Migrations;

namespace Touring.DataAccess.Migrations
{
    public partial class BugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerGroups_TourHeader_TourBookId",
                table: "PassengerGroups");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerGroups_TourBook_TourBookId",
                table: "PassengerGroups",
                column: "TourBookId",
                principalTable: "TourBook",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerGroups_TourBook_TourBookId",
                table: "PassengerGroups");

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerGroups_TourHeader_TourBookId",
                table: "PassengerGroups",
                column: "TourBookId",
                principalTable: "TourHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
