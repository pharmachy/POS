using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class SupplierA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupplierAId",
                table: "ContactPerson",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SupplierA",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Contact = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierA", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactPerson_SupplierAId",
                table: "ContactPerson",
                column: "SupplierAId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactPerson_SupplierA_SupplierAId",
                table: "ContactPerson",
                column: "SupplierAId",
                principalTable: "SupplierA",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactPerson_SupplierA_SupplierAId",
                table: "ContactPerson");

            migrationBuilder.DropTable(
                name: "SupplierA");

            migrationBuilder.DropIndex(
                name: "IX_ContactPerson_SupplierAId",
                table: "ContactPerson");

            migrationBuilder.DropColumn(
                name: "SupplierAId",
                table: "ContactPerson");
        }
    }
}
