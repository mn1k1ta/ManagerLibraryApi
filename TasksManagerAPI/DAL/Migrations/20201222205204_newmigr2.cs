using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class newmigr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskModels_UserModels_UserModelUserId",
                table: "TaskModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TaskModels",
                table: "TaskModels");

            migrationBuilder.RenameTable(
                name: "TaskModels",
                newName: "DocumentModels");

            migrationBuilder.RenameIndex(
                name: "IX_TaskModels_UserModelUserId",
                table: "DocumentModels",
                newName: "IX_DocumentModels_UserModelUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentModels",
                table: "DocumentModels",
                column: "DocumetnId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentModels_UserModels_UserModelUserId",
                table: "DocumentModels",
                column: "UserModelUserId",
                principalTable: "UserModels",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentModels_UserModels_UserModelUserId",
                table: "DocumentModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentModels",
                table: "DocumentModels");

            migrationBuilder.RenameTable(
                name: "DocumentModels",
                newName: "TaskModels");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentModels_UserModelUserId",
                table: "TaskModels",
                newName: "IX_TaskModels_UserModelUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TaskModels",
                table: "TaskModels",
                column: "DocumetnId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskModels_UserModels_UserModelUserId",
                table: "TaskModels",
                column: "UserModelUserId",
                principalTable: "UserModels",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
