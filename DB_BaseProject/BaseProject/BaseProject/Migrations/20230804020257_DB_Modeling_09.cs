using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class DB_Modeling_09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogModels_InventoryModels_InventoryModelId",
                table: "InventoryLogModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogModels_ProductModels_ProductId",
                table: "InventoryLogModels");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryModels_ProductModels_ProductId",
                table: "InventoryModels");

            migrationBuilder.DropIndex(
                name: "IX_InventoryModels_ProductId",
                table: "InventoryModels");

            migrationBuilder.DropIndex(
                name: "IX_InventoryLogModels_InventoryModelId",
                table: "InventoryLogModels");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "InventoryModels");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "InventoryModels");

            migrationBuilder.DropColumn(
                name: "InventoryModelId",
                table: "InventoryLogModels");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "InventoryLogModels",
                newName: "InventoryId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLogModels_ProductId",
                table: "InventoryLogModels",
                newName: "IX_InventoryLogModels_InventoryId");

            migrationBuilder.CreateTable(
                name: "InventoryProductModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    InventoryModelId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProductModel_InventoryModelId",
                table: "InventoryProductModel",
                column: "InventoryModelId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryProductModel_ProductId",
                table: "InventoryProductModel",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogModels_InventoryModels_InventoryId",
                table: "InventoryLogModels",
                column: "InventoryId",
                principalTable: "InventoryModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogModels_InventoryModels_InventoryId",
                table: "InventoryLogModels");

            migrationBuilder.DropTable(
                name: "InventoryProductModel");

            migrationBuilder.RenameColumn(
                name: "InventoryId",
                table: "InventoryLogModels",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLogModels_InventoryId",
                table: "InventoryLogModels",
                newName: "IX_InventoryLogModels_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "InventoryModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "InventoryModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InventoryModelId",
                table: "InventoryLogModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryModels_ProductId",
                table: "InventoryModels",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogModels_InventoryModelId",
                table: "InventoryLogModels",
                column: "InventoryModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogModels_InventoryModels_InventoryModelId",
                table: "InventoryLogModels",
                column: "InventoryModelId",
                principalTable: "InventoryModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogModels_ProductModels_ProductId",
                table: "InventoryLogModels",
                column: "ProductId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryModels_ProductModels_ProductId",
                table: "InventoryModels",
                column: "ProductId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
