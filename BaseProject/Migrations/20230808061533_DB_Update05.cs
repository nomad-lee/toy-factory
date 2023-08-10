using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class DB_Update05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Models_Product_Models_ProductModelId",
                table: "Inventory_Models");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Models_ProductModelId",
                table: "Inventory_Models");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                table: "Inventory_Models");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Models_ProductId",
                table: "Inventory_Models",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Models_Product_Models_ProductId",
                table: "Inventory_Models",
                column: "ProductId",
                principalTable: "Product_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Models_Product_Models_ProductId",
                table: "Inventory_Models");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Models_ProductId",
                table: "Inventory_Models");

            migrationBuilder.AddColumn<int>(
                name: "ProductModelId",
                table: "Inventory_Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Models_ProductModelId",
                table: "Inventory_Models",
                column: "ProductModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Models_Product_Models_ProductModelId",
                table: "Inventory_Models",
                column: "ProductModelId",
                principalTable: "Product_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
