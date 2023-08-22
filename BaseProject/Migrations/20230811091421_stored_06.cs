using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class stored_06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materal_Stored_Log_Models_Material_Models_Material_ModelId",
                table: "Materal_Stored_Log_Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_Edit_Log_Models_Material_Models_Material_ModelId",
                table: "Material_Edit_Log_Models");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Material_Edit_Log_Models");

            migrationBuilder.DropColumn(
                name: "MaterialId",
                table: "Materal_Stored_Log_Models");

            migrationBuilder.RenameColumn(
                name: "Material_ModelId",
                table: "Material_Edit_Log_Models",
                newName: "MetrailId");

            migrationBuilder.RenameIndex(
                name: "IX_Material_Edit_Log_Models_Material_ModelId",
                table: "Material_Edit_Log_Models",
                newName: "IX_Material_Edit_Log_Models_MetrailId");

            migrationBuilder.RenameColumn(
                name: "Material_ModelId",
                table: "Materal_Stored_Log_Models",
                newName: "MetrailId");

            migrationBuilder.RenameIndex(
                name: "IX_Materal_Stored_Log_Models_Material_ModelId",
                table: "Materal_Stored_Log_Models",
                newName: "IX_Materal_Stored_Log_Models_MetrailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materal_Stored_Log_Models_Material_Models_MetrailId",
                table: "Materal_Stored_Log_Models",
                column: "MetrailId",
                principalTable: "Material_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Edit_Log_Models_Material_Models_MetrailId",
                table: "Material_Edit_Log_Models",
                column: "MetrailId",
                principalTable: "Material_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materal_Stored_Log_Models_Material_Models_MetrailId",
                table: "Materal_Stored_Log_Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Material_Edit_Log_Models_Material_Models_MetrailId",
                table: "Material_Edit_Log_Models");

            migrationBuilder.RenameColumn(
                name: "MetrailId",
                table: "Material_Edit_Log_Models",
                newName: "Material_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Material_Edit_Log_Models_MetrailId",
                table: "Material_Edit_Log_Models",
                newName: "IX_Material_Edit_Log_Models_Material_ModelId");

            migrationBuilder.RenameColumn(
                name: "MetrailId",
                table: "Materal_Stored_Log_Models",
                newName: "Material_ModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Materal_Stored_Log_Models_MetrailId",
                table: "Materal_Stored_Log_Models",
                newName: "IX_Materal_Stored_Log_Models_Material_ModelId");

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Material_Edit_Log_Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaterialId",
                table: "Materal_Stored_Log_Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Materal_Stored_Log_Models_Material_Models_Material_ModelId",
                table: "Materal_Stored_Log_Models",
                column: "Material_ModelId",
                principalTable: "Material_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Edit_Log_Models_Material_Models_Material_ModelId",
                table: "Material_Edit_Log_Models",
                column: "Material_ModelId",
                principalTable: "Material_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
