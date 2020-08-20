using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class OrdderdatestringRemoveProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderDateString",
                table: "PO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderDateString",
                table: "PO",
                nullable: true);
        }
    }
}
