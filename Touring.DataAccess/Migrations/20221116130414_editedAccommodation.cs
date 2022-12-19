using Microsoft.EntityFrameworkCore.Migrations;

namespace Touring.DataAccess.Migrations
{
    public partial class editedAccommodation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Recommendations",
                table: "Accommodation",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Recommendations",
                table: "Accommodation");
        }
    }
}
