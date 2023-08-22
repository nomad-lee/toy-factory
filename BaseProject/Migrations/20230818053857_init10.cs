using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class init10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IoT_Data_Models_IoT_Models_IoTModelId",
                table: "IoT_Data_Models");

            migrationBuilder.RenameColumn(
                name: "IoTModelId",
                table: "IoT_Data_Models",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "IoT_Data_Models",
                newName: "Count");

            migrationBuilder.RenameIndex(
                name: "IX_IoT_Data_Models_IoTModelId",
                table: "IoT_Data_Models",
                newName: "IX_IoT_Data_Models_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_IoT_Data_Models_Product_Models_ProductId",
                table: "IoT_Data_Models",
                column: "ProductId",
                principalTable: "Product_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IoT_Data_Models_Product_Models_ProductId",
                table: "IoT_Data_Models");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "IoT_Data_Models",
                newName: "IoTModelId");

            migrationBuilder.RenameColumn(
                name: "Count",
                table: "IoT_Data_Models",
                newName: "Data");

            migrationBuilder.RenameIndex(
                name: "IX_IoT_Data_Models_ProductId",
                table: "IoT_Data_Models",
                newName: "IX_IoT_Data_Models_IoTModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_IoT_Data_Models_IoT_Models_IoTModelId",
                table: "IoT_Data_Models",
                column: "IoTModelId",
                principalTable: "IoT_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
