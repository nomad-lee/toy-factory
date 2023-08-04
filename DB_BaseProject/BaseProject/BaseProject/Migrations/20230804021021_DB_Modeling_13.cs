using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class DB_Modeling_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginLogModels_AspNetUsers_UserIdentityId1",
                table: "LoginLogModels");

            migrationBuilder.DropIndex(
                name: "IX_LoginLogModels_UserIdentityId1",
                table: "LoginLogModels");

            migrationBuilder.DropColumn(
                name: "UserIdentityId1",
                table: "LoginLogModels");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdentityId",
                table: "LoginLogModels",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LoginLogModels_UserIdentityId",
                table: "LoginLogModels",
                column: "UserIdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginLogModels_AspNetUsers_UserIdentityId",
                table: "LoginLogModels",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginLogModels_AspNetUsers_UserIdentityId",
                table: "LoginLogModels");

            migrationBuilder.DropIndex(
                name: "IX_LoginLogModels_UserIdentityId",
                table: "LoginLogModels");

            migrationBuilder.AlterColumn<int>(
                name: "UserIdentityId",
                table: "LoginLogModels",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserIdentityId1",
                table: "LoginLogModels",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LoginLogModels_UserIdentityId1",
                table: "LoginLogModels",
                column: "UserIdentityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginLogModels_AspNetUsers_UserIdentityId1",
                table: "LoginLogModels",
                column: "UserIdentityId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
