using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class POorderString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PurchaseOrderNo",
                table: "PO",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PurchaseOrderNo",
                table: "PO",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
