using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Migrations
{
    public partial class addedPosterPath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posters_ConcertId",
                table: "Posters");

            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "Concerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Posters_ConcertId",
                table: "Posters",
                column: "ConcertId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Posters_ConcertId",
                table: "Posters");

            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Concerts");

            migrationBuilder.CreateIndex(
                name: "IX_Posters_ConcertId",
                table: "Posters",
                column: "ConcertId",
                unique: true);
        }
    }
}
