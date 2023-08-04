using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class DB_Modeling_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEditLogModels_AspNetUsers_UserIdentityId1",
                table: "UserEditLogModels");

            migrationBuilder.DropIndex(
                name: "IX_UserEditLogModels_UserIdentityId1",
                table: "UserEditLogModels");

            migrationBuilder.DropColumn(
                name: "UserIdentityId1",
                table: "UserEditLogModels");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdentityId",
                table: "UserEditLogModels",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserEditLogModels_UserIdentityId",
                table: "UserEditLogModels",
                column: "UserIdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEditLogModels_AspNetUsers_UserIdentityId",
                table: "UserEditLogModels",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEditLogModels_AspNetUsers_UserIdentityId",
                table: "UserEditLogModels");

            migrationBuilder.DropIndex(
                name: "IX_UserEditLogModels_UserIdentityId",
                table: "UserEditLogModels");

            migrationBuilder.AlterColumn<int>(
                name: "UserIdentityId",
                table: "UserEditLogModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserIdentityId1",
                table: "UserEditLogModels",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_UserEditLogModels_UserIdentityId1",
                table: "UserEditLogModels",
                column: "UserIdentityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEditLogModels_AspNetUsers_UserIdentityId1",
                table: "UserEditLogModels",
                column: "UserIdentityId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
