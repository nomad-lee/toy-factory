using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class DB_Update_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginLogModels_AspNetUsers_UserIdentityId",
                table: "LoginLogModels");

            migrationBuilder.DropTable(
                name: "InventoryProductModel");

            migrationBuilder.DropTable(
                name: "ProductModelProductUseMetrailModel");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "ProductModels",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "ProductModels",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "MetrailId",
                table: "ProductUseMetrailModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Metrail_count",
                table: "ProductUseMetrailModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProductUseMetrailModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "ProductModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdentityId",
                table: "LoginLogModels",
                type: "varchar(255)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "LoginTime",
                table: "LoginLogModels",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "LoginLogModels",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Inventory_Product_Model",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Inventory_ModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory_Product_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Product_Model_InventoryModels_Inventory_ModelId",
                        column: x => x.Inventory_ModelId,
                        principalTable: "InventoryModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Inventory_Product_Model_ProductModels_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUseMetrailModels_MetrailId",
                table: "ProductUseMetrailModels",
                column: "MetrailId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUseMetrailModels_ProductId",
                table: "ProductUseMetrailModels",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Product_Model_Inventory_ModelId",
                table: "Inventory_Product_Model",
                column: "Inventory_ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Product_Model_ProductId",
                table: "Inventory_Product_Model",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginLogModels_AspNetUsers_UserIdentityId",
                table: "LoginLogModels",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUseMetrailModels_MaterialModels_MetrailId",
                table: "ProductUseMetrailModels",
                column: "MetrailId",
                principalTable: "MaterialModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUseMetrailModels_ProductModels_ProductId",
                table: "ProductUseMetrailModels",
                column: "ProductId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginLogModels_AspNetUsers_UserIdentityId",
                table: "LoginLogModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUseMetrailModels_MaterialModels_MetrailId",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUseMetrailModels_ProductModels_ProductId",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropTable(
                name: "Inventory_Product_Model");

            migrationBuilder.DropIndex(
                name: "IX_ProductUseMetrailModels_MetrailId",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropIndex(
                name: "IX_ProductUseMetrailModels_ProductId",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropColumn(
                name: "MetrailId",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropColumn(
                name: "Metrail_count",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ProductModels");

            migrationBuilder.DropColumn(
                name: "LoginTime",
                table: "LoginLogModels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LoginLogModels");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ProductModels",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProductModels",
                newName: "name");

            migrationBuilder.UpdateData(
                table: "LoginLogModels",
                keyColumn: "UserIdentityId",
                keyValue: null,
                column: "UserIdentityId",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdentityId",
                table: "LoginLogModels",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "InventoryProductModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InventoryModelId = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryProductModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryProductModel_InventoryModels_InventoryModelId",
                        column: x => x.InventoryModelId,
                        principalTable: "InventoryModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_InventoryProductModel_ProductModels_ProductId",
                        column: x => x.ProductId,
                        principalTable: "ProductModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductModelProductUseMetrailModel",
                columns: table => new
                {
                    ProductModelsId = table.Column<int>(type: "int", nullable: false),
                    ProductUseMetrailModelsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModelProductUseMetrailModel", x => new { x.ProductModelsId, x.ProductUseMetrailModelsId });
                    table.ForeignKey(
                        name: "FK_ProductModelProductUseMetrailModel_ProductModels_ProductMode~",
                        column: x => x.ProductModelsId,
                        principalTable: "ProductModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModelProductUseMetrailModel_ProductUseMetrailModels_P~",
                        column: x => x.ProductUseMetrailModelsId,
                        principalTable: "ProductUseMetrailModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProductModel_InventoryModelId",
                table: "InventoryProductModel",
                column: "InventoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProductModel_ProductId",
                table: "InventoryProductModel",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductModelProductUseMetrailModel_ProductUseMetrailModelsId",
                table: "ProductModelProductUseMetrailModel",
                column: "ProductUseMetrailModelsId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginLogModels_AspNetUsers_UserIdentityId",
                table: "LoginLogModels",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
