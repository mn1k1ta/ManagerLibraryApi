using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class newmigr3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "UserModels");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "UserModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Group",
                table: "UserModels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "UserModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "UserModels");

            migrationBuilder.DropColumn(
                name: "Group",
                table: "UserModels");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "UserModels");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "UserModels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
