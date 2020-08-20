using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class POrderDisPerpropAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPer",
                table: "OrderDetail",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPer",
                table: "OrderDetail");
        }
    }
}
