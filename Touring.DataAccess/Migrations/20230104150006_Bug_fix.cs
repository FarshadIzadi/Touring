using Microsoft.EntityFrameworkCore.Migrations;

namespace Touring.DataAccess.Migrations
{
    public partial class Bug_fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourBook_TourHeader_TourId",
                table: "TourBook");

            migrationBuilder.DropIndex(
                name: "IX_TourBook_TourId",
                table: "TourBook");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "TourBook");

            migrationBuilder.CreateIndex(
                name: "IX_TourBook_TourHeaderId",
                table: "TourBook",
                column: "TourHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourBook_TourHeader_TourHeaderId",
                table: "TourBook",
                column: "TourHeaderId",
                principalTable: "TourHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourBook_TourHeader_TourHeaderId",
                table: "TourBook");

            migrationBuilder.DropIndex(
                name: "IX_TourBook_TourHeaderId",
                table: "TourBook");

            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "TourBook",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourBook_TourId",
                table: "TourBook",
                column: "TourId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourBook_TourHeader_TourId",
                table: "TourBook",
                column: "TourId",
                principalTable: "TourHeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
