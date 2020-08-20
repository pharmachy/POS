using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class SupplierIdaddedOnPOandRemovedfromDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "OrderDetail");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "PO",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "PO");

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "OrderDetail",
                nullable: false,
                defaultValue: 0);
        }
    }
}
