using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class DB_Update_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductUseMetrailModels_MaterialModels_MetrailId",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropIndex(
                name: "IX_ProductUseMetrailModels_MetrailId",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropColumn(
                name: "MetrailId",
                table: "ProductUseMetrailModels");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MetrailId",
                table: "ProductUseMetrailModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductUseMetrailModels_MetrailId",
                table: "ProductUseMetrailModels",
                column: "MetrailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUseMetrailModels_MaterialModels_MetrailId",
                table: "ProductUseMetrailModels",
                column: "MetrailId",
                principalTable: "MaterialModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
