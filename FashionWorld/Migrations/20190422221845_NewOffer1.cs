using Microsoft.EntityFrameworkCore.Migrations;

namespace FashionWorld.Migrations
{
    public partial class NewOffer1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "SalePrice",
                table: "Products",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
