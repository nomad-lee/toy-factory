using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class stored_02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Edit_Log_Models_Material_Models_MaterialId",
                table: "Material_Edit_Log_Models");

            migrationBuilder.DropIndex(
                name: "IX_Material_Edit_Log_Models_MaterialId",
                table: "Material_Edit_Log_Models");

            migrationBuilder.AddColumn<int>(
                name: "Material_ModelId",
                table: "Material_Edit_Log_Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Material_Edit_Log_Models_Material_ModelId",
                table: "Material_Edit_Log_Models",
                column: "Material_ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Edit_Log_Models_Material_Models_Material_ModelId",
                table: "Material_Edit_Log_Models",
                column: "Material_ModelId",
                principalTable: "Material_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Edit_Log_Models_Material_Models_Material_ModelId",
                table: "Material_Edit_Log_Models");

            migrationBuilder.DropIndex(
                name: "IX_Material_Edit_Log_Models_Material_ModelId",
                table: "Material_Edit_Log_Models");

            migrationBuilder.DropColumn(
                name: "Material_ModelId",
                table: "Material_Edit_Log_Models");

            migrationBuilder.CreateIndex(
                name: "IX_Material_Edit_Log_Models_MaterialId",
                table: "Material_Edit_Log_Models",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_Material_Edit_Log_Models_Material_Models_MaterialId",
                table: "Material_Edit_Log_Models",
                column: "MaterialId",
                principalTable: "Material_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
