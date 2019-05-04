using Microsoft.EntityFrameworkCore.Migrations;

namespace FashionWorld.Migrations
{
    public partial class userimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_AspNetUsers_AppUSerId",
                table: "Favorites");

            migrationBuilder.RenameColumn(
                name: "AppUSerId",
                table: "Favorites",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_AppUSerId",
                table: "Favorites",
                newName: "IX_Favorites_AppUserId");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_AspNetUsers_AppUserId",
                table: "Favorites",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_AspNetUsers_AppUserId",
                table: "Favorites");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Favorites",
                newName: "AppUSerId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_AppUserId",
                table: "Favorites",
                newName: "IX_Favorites_AppUSerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_AspNetUsers_AppUSerId",
                table: "Favorites",
                column: "AppUSerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
