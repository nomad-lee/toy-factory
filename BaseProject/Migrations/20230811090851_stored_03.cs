using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class stored_03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materal_Stored_Log_Models_Material_Models_MaterialId",
                table: "Materal_Stored_Log_Models");

            migrationBuilder.DropIndex(
                name: "IX_Materal_Stored_Log_Models_MaterialId",
                table: "Materal_Stored_Log_Models");

            migrationBuilder.RenameColumn(
                name: "MateralId",
                table: "Materal_Stored_Log_Models",
                newName: "Material_ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Materal_Stored_Log_Models_Material_ModelId",
                table: "Materal_Stored_Log_Models",
                column: "Material_ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materal_Stored_Log_Models_Material_Models_Material_ModelId",
                table: "Materal_Stored_Log_Models",
                column: "Material_ModelId",
                principalTable: "Material_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materal_Stored_Log_Models_Material_Models_Material_ModelId",
                table: "Materal_Stored_Log_Models");

            migrationBuilder.DropIndex(
                name: "IX_Materal_Stored_Log_Models_Material_ModelId",
                table: "Materal_Stored_Log_Models");

            migrationBuilder.RenameColumn(
                name: "Material_ModelId",
                table: "Materal_Stored_Log_Models",
                newName: "MateralId");

            migrationBuilder.CreateIndex(
                name: "IX_Materal_Stored_Log_Models_MaterialId",
                table: "Materal_Stored_Log_Models",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materal_Stored_Log_Models_Material_Models_MaterialId",
                table: "Materal_Stored_Log_Models",
                column: "MaterialId",
                principalTable: "Material_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
