using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class PoPropAddedDiscountAndNetTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "NetDiscount",
                table: "PO",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NetTotal",
                table: "PO",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NetDiscount",
                table: "PO");

            migrationBuilder.DropColumn(
                name: "NetTotal",
                table: "PO");
        }
    }
}
