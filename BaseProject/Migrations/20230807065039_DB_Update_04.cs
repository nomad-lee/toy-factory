using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class DB_Update_04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Metrail_count",
                table: "ProductUseMetrailModels",
                newName: "MetrailId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductUseMetrailModels_MaterialModels_MetrailId",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropIndex(
                name: "IX_ProductUseMetrailModels_MetrailId",
                table: "ProductUseMetrailModels");

            migrationBuilder.RenameColumn(
                name: "MetrailId",
                table: "ProductUseMetrailModels",
                newName: "Metrail_count");
        }
    }
}
