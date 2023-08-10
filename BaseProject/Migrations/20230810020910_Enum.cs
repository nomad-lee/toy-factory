using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class Enum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgUrl",
                table: "Material_Edit_Log_Models");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Material_Edit_Log_Models");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Material_Edit_Log_Models");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Material_Edit_Log_Models");

            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "Material_Edit_Log_Models",
                newName: "MaterialId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Product_Models",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Order_Models",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Material_Models",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "EditTime",
                table: "Material_Edit_Log_Models",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Products_ProductId",
                table: "Order_Products",
                column: "ProductId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Products_Product_Models_ProductId",
                table: "Order_Products",
                column: "ProductId",
                principalTable: "Product_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Material_Edit_Log_Models_Material_Models_MaterialId",
                table: "Material_Edit_Log_Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Products_Product_Models_ProductId",
                table: "Order_Products");

            migrationBuilder.DropIndex(
                name: "IX_Order_Products_ProductId",
                table: "Order_Products");

            migrationBuilder.DropIndex(
                name: "IX_Material_Edit_Log_Models_MaterialId",
                table: "Material_Edit_Log_Models");

            migrationBuilder.DropColumn(
                name: "EditTime",
                table: "Material_Edit_Log_Models");

            migrationBuilder.RenameColumn(
                name: "MaterialId",
                table: "Material_Edit_Log_Models",
                newName: "Quantity");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Product_Models",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Order_Models",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Material_Models",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImgUrl",
                table: "Material_Edit_Log_Models",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Material_Edit_Log_Models",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Material_Edit_Log_Models",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Material_Edit_Log_Models",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "AspNetUsers",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
