using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class DB_Update03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory_Log_Models");

            migrationBuilder.DropTable(
                name: "Inventory_Product_Model");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "Inventory_Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Inventory_Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductModelId",
                table: "Inventory_Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Inventory_Edit_Log_Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    EditTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Edit_Log_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Edit_Log_Model_Inventory_Models_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory_Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Models_ProductModelId",
                table: "Inventory_Models",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Edit_Log_Model_InventoryId",
                table: "Inventory_Edit_Log_Model",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Models_Product_Models_ProductModelId",
                table: "Inventory_Models",
                column: "ProductModelId",
                principalTable: "Product_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Models_Product_Models_ProductModelId",
                table: "Inventory_Models");

            migrationBuilder.DropTable(
                name: "Inventory_Edit_Log_Model");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Models_ProductModelId",
                table: "Inventory_Models");

            migrationBuilder.DropColumn(
                name: "Count",
                table: "Inventory_Models");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Inventory_Models");

            migrationBuilder.DropColumn(
                name: "ProductModelId",
                table: "Inventory_Models");

            migrationBuilder.CreateTable(
                name: "Inventory_Log_Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    EditTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Log_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Log_Models_Inventory_Models_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory_Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventory_Product_Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Inventory_ModelId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Product_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_Model_Inventory_Models_Inventory_ModelId",
                        column: x => x.Inventory_ModelId,
                        principalTable: "Inventory_Models",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_Product_Model_Product_Models_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product_Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Log_Models_InventoryId",
                table: "Inventory_Log_Models",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Product_Model_Inventory_ModelId",
                table: "Inventory_Product_Model",
                column: "Inventory_ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Product_Model_ProductId",
                table: "Inventory_Product_Model",
                column: "ProductId");
        }
    }
}
