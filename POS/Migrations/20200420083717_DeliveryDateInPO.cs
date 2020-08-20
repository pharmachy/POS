using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class DeliveryDateInPO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "PO",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "PO");
        }
    }
}
