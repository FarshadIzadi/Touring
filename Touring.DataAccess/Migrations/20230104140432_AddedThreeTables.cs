using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Touring.DataAccess.Migrations
{
    public partial class AddedThreeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PassengerGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FristName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TourBookId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PassportStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassportExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VisaStatus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VisaExpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vaccinetatus = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PassengerGroups_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PassengerGroups_TourHeader_TourBookId",
                        column: x => x.TourBookId,
                        principalTable: "TourHeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerGroups_TourBookId",
                table: "PassengerGroups",
                column: "TourBookId");

            migrationBuilder.CreateIndex(
                name: "IX_PassengerGroups_UserId",
                table: "PassengerGroups",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassengerGroups");
        }
    }
}
