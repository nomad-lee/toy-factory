using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class DB_Update06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Products_Product_Models_ProductId",
                table: "Order_Products");

            migrationBuilder.DropIndex(
                name: "IX_Order_Products_ProductId",
                table: "Order_Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisterDate",
                table: "Order_Models",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Order_Models",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegisterDate",
                table: "Order_Models",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "EndDate",
                table: "Order_Models",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Products_ProductId",
                table: "Order_Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Products_Product_Models_ProductId",
                table: "Order_Products",
                column: "ProductId",
                principalTable: "Product_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
