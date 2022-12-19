using Microsoft.EntityFrameworkCore.Migrations;

namespace Touring.DataAccess.Migrations
{
    public partial class addmigrationadded_Meals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealId",
                table: "TourDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TourDetails_MealId",
                table: "TourDetails",
                column: "MealId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourDetails_Accommodation_MealId",
                table: "TourDetails",
                column: "MealId",
                principalTable: "Accommodation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourDetails_Accommodation_MealId",
                table: "TourDetails");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_TourDetails_MealId",
                table: "TourDetails");

            migrationBuilder.DropColumn(
                name: "MealId",
                table: "TourDetails");
        }
    }
}
