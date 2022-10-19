using Microsoft.EntityFrameworkCore.Migrations;

namespace Touring.DataAccess.Migrations
{
    public partial class edtionToTourDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourDetails_TourHeader_TourId",
                table: "TourDetails");

            migrationBuilder.DropIndex(
                name: "IX_TourDetails_TourId",
                table: "TourDetails");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "TourDetails");

            migrationBuilder.CreateIndex(
                name: "IX_TourDetails_TourHeaderId",
                table: "TourDetails",
                column: "TourHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourDetails_TourHeader_TourHeaderId",
                table: "TourDetails",
                column: "TourHeaderId",
                principalTable: "TourHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourDetails_TourHeader_TourHeaderId",
                table: "TourDetails");

            migrationBuilder.DropIndex(
                name: "IX_TourDetails_TourHeaderId",
                table: "TourDetails");

            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "TourDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourDetails_TourId",
                table: "TourDetails",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourDetails_TourHeader_TourId",
                table: "TourDetails",
                column: "TourId",
                principalTable: "TourHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
