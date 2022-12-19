using Microsoft.EntityFrameworkCore.Migrations;

namespace Touring.DataAccess.Migrations
{
    public partial class editeMealId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourDetails_Accommodation_MealId",
                table: "TourDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_TourDetails_Meals_MealId",
                table: "TourDetails",
                column: "MealId",
                principalTable: "Meals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourDetails_Meals_MealId",
                table: "TourDetails");

            migrationBuilder.AddForeignKey(
                name: "FK_TourDetails_Accommodation_MealId",
                table: "TourDetails",
                column: "MealId",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
