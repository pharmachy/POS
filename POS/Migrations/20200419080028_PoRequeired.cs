using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class PoRequeired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PurchaseOrderNo",
                table: "PO",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PurchaseOrderNo",
                table: "PO",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
