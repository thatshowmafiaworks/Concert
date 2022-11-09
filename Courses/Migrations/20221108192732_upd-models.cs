using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Courses.Migrations
{
    public partial class updmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "Tickets");

            migrationBuilder.RenameColumn(
                name: "BeginningDate",
                table: "Tickets",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Concerts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Place",
                table: "Concerts");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Tickets",
                newName: "BeginningDate");

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
