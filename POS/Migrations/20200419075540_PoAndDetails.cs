using Microsoft.EntityFrameworkCore.Migrations;

namespace POS.Migrations
{
    public partial class PoAndDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Brands_BrandId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_BrandModels_BrandModelId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Categories_CategoryId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Companies_CompanyId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_SubCategories_SubCategoryId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Suppliers_SupplierId",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_BrandId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_BrandModelId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_CategoryId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_CompanyId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_SubCategoryId",
                table: "OrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetail_SupplierId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BrandId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "BrandModelId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "OrderDetail");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "OrderDetail");

            migrationBuilder.RenameColumn(
                name: "OrderItemId",
                table: "OrderDetail",
                newName: "OrderDetailId");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "OrderDetail",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "OrderDetail",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "OrderDetail",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Rate",
                table: "OrderDetail",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrderDetail",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDetailId",
                table: "OrderDetail",
                newName: "OrderItemId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TotalAmount",
                table: "OrderDetail",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "SupplierId",
                table: "OrderDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "OrderDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Rate",
                table: "OrderDetail",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "OrderDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "BrandId",
                table: "OrderDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrandModelId",
                table: "OrderDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "OrderDetail",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "OrderDetail",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_BrandId",
                table: "OrderDetail",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_BrandModelId",
                table: "OrderDetail",
                column: "BrandModelId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_CategoryId",
                table: "OrderDetail",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_CompanyId",
                table: "OrderDetail",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ProductId",
                table: "OrderDetail",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_SubCategoryId",
                table: "OrderDetail",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_SupplierId",
                table: "OrderDetail",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Brands_BrandId",
                table: "OrderDetail",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_BrandModels_BrandModelId",
                table: "OrderDetail",
                column: "BrandModelId",
                principalTable: "BrandModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Categories_CategoryId",
                table: "OrderDetail",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Companies_CompanyId",
                table: "OrderDetail",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Products_ProductId",
                table: "OrderDetail",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_SubCategories_SubCategoryId",
                table: "OrderDetail",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Suppliers_SupplierId",
                table: "OrderDetail",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
