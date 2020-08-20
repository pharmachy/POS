using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class purchasePROPorderID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseDetailsId",
                table: "Purchases",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PurchaseDetailsId",
                table: "Purchases");
        }
    }
}
