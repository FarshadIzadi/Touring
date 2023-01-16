using Microsoft.EntityFrameworkCore.Migrations;

namespace Touring.DataAccess.Migrations
{
    public partial class addDiscountToBookTour : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "TourBook",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TourBook_DiscountId",
                table: "TourBook",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourBook_Discounts_DiscountId",
                table: "TourBook",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourBook_Discounts_DiscountId",
                table: "TourBook");

            migrationBuilder.DropIndex(
                name: "IX_TourBook_DiscountId",
                table: "TourBook");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "TourBook");
        }
    }
}
