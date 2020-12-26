using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class newmigr4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentModels_UserModels_UserModelUserId",
                table: "DocumentModels");

            migrationBuilder.DropIndex(
                name: "IX_DocumentModels_UserModelUserId",
                table: "DocumentModels");

            migrationBuilder.DropColumn(
                name: "UserModelUserId",
                table: "DocumentModels");

            migrationBuilder.AddColumn<int>(
                name: "UserModelId",
                table: "DocumentModels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentModels_UserModelId",
                table: "DocumentModels",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentModels_UserModels_UserModelId",
                table: "DocumentModels",
                column: "UserModelId",
                principalTable: "UserModels",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentModels_UserModels_UserModelId",
                table: "DocumentModels");

            migrationBuilder.DropIndex(
                name: "IX_DocumentModels_UserModelId",
                table: "DocumentModels");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "DocumentModels");

            migrationBuilder.AddColumn<int>(
                name: "UserModelUserId",
                table: "DocumentModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentModels_UserModelUserId",
                table: "DocumentModels",
                column: "UserModelUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentModels_UserModels_UserModelUserId",
                table: "DocumentModels",
                column: "UserModelUserId",
                principalTable: "UserModels",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
