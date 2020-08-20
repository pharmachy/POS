using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class PurchaseByPO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Purchases",
                nullable: true,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "NetDiscount",
                table: "PO",
                nullable: true,
                oldClrType: typeof(decimal));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<decimal>(
                name: "Discount",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "NetDiscount",
                table: "PO",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}
