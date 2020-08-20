using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class PropBrrandChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Companies_CompanyId",
                table: "Brands");

            migrationBuilder.DropIndex(
                name: "IX_Brands_CompanyId",
                table: "Brands");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Brands",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "Brands",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Brands_CompanyId",
                table: "Brands",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Companies_CompanyId",
                table: "Brands",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
