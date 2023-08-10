using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BaseProject.Migrations
{
    /// <inheritdoc />
    public partial class DB_Update_06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_Model_InventoryModels_Inventory_ModelId",
                table: "Inventory_Product_Model");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_Model_ProductModels_ProductId",
                table: "Inventory_Product_Model");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogModels_InventoryModels_InventoryId",
                table: "InventoryLogModels");

            migrationBuilder.DropForeignKey(
                name: "FK_IoTDataModels_IoTModels_IoTModelId",
                table: "IoTDataModels");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginLogModels_AspNetUsers_UserIdentityId",
                table: "LoginLogModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderEditLogModels_OrderModels_OrderId",
                table: "OrderEditLogModels");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_OrderModels_OrderId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProducts_ProductModels_ProductId",
                table: "OrderProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductEditLogModels_ProductModels_ProductId",
                table: "ProductEditLogModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUseMetrailModels_MaterialModels_MetrailId",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUseMetrailModels_ProductModels_ProductId",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropForeignKey(
                name: "FK_UserEditLogModels_AspNetUsers_UserIdentityId",
                table: "UserEditLogModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserEditLogModels",
                table: "UserEditLogModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUseMetrailModels",
                table: "ProductUseMetrailModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductModels",
                table: "ProductModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductEditLogModels",
                table: "ProductEditLogModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderEditLogModels",
                table: "OrderEditLogModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MaterialModels",
                table: "MaterialModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginLogModels",
                table: "LoginLogModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IoTModels",
                table: "IoTModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IoTDataModels",
                table: "IoTDataModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryModels",
                table: "InventoryModels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryLogModels",
                table: "InventoryLogModels");

            migrationBuilder.RenameTable(
                name: "UserEditLogModels",
                newName: "User_Edit_Log_Models");

            migrationBuilder.RenameTable(
                name: "ProductUseMetrailModels",
                newName: "Product_Use_Metrail_Models");

            migrationBuilder.RenameTable(
                name: "ProductModels",
                newName: "Product_Models");

            migrationBuilder.RenameTable(
                name: "ProductEditLogModels",
                newName: "Product_Edit_Log_Models");

            migrationBuilder.RenameTable(
                name: "OrderProducts",
                newName: "Order_Products");

            migrationBuilder.RenameTable(
                name: "OrderModels",
                newName: "Order_Models");

            migrationBuilder.RenameTable(
                name: "OrderEditLogModels",
                newName: "Order_Edit_Log_Models");

            migrationBuilder.RenameTable(
                name: "MaterialModels",
                newName: "Material_Models");

            migrationBuilder.RenameTable(
                name: "LoginLogModels",
                newName: "Login_Log_Models");

            migrationBuilder.RenameTable(
                name: "IoTModels",
                newName: "IoT_Models");

            migrationBuilder.RenameTable(
                name: "IoTDataModels",
                newName: "IoT_Data_Models");

            migrationBuilder.RenameTable(
                name: "InventoryModels",
                newName: "Inventory_Models");

            migrationBuilder.RenameTable(
                name: "InventoryLogModels",
                newName: "Inventory_Log_Models");

            migrationBuilder.RenameIndex(
                name: "IX_UserEditLogModels_UserIdentityId",
                table: "User_Edit_Log_Models",
                newName: "IX_User_Edit_Log_Models_UserIdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUseMetrailModels_ProductId",
                table: "Product_Use_Metrail_Models",
                newName: "IX_Product_Use_Metrail_Models_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUseMetrailModels_MetrailId",
                table: "Product_Use_Metrail_Models",
                newName: "IX_Product_Use_Metrail_Models_MetrailId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductEditLogModels_ProductId",
                table: "Product_Edit_Log_Models",
                newName: "IX_Product_Edit_Log_Models_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_ProductId",
                table: "Order_Products",
                newName: "IX_Order_Products_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderProducts_OrderId",
                table: "Order_Products",
                newName: "IX_Order_Products_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderEditLogModels_OrderId",
                table: "Order_Edit_Log_Models",
                newName: "IX_Order_Edit_Log_Models_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_LoginLogModels_UserIdentityId",
                table: "Login_Log_Models",
                newName: "IX_Login_Log_Models_UserIdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_IoTDataModels_IoTModelId",
                table: "IoT_Data_Models",
                newName: "IX_IoT_Data_Models_IoTModelId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLogModels_InventoryId",
                table: "Inventory_Log_Models",
                newName: "IX_Inventory_Log_Models_InventoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Edit_Log_Models",
                table: "User_Edit_Log_Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Use_Metrail_Models",
                table: "Product_Use_Metrail_Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Models",
                table: "Product_Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product_Edit_Log_Models",
                table: "Product_Edit_Log_Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Products",
                table: "Order_Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Models",
                table: "Order_Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Edit_Log_Models",
                table: "Order_Edit_Log_Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Material_Models",
                table: "Material_Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Login_Log_Models",
                table: "Login_Log_Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IoT_Models",
                table: "IoT_Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IoT_Data_Models",
                table: "IoT_Data_Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory_Models",
                table: "Inventory_Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory_Log_Models",
                table: "Inventory_Log_Models",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Log_Models_Inventory_Models_InventoryId",
                table: "Inventory_Log_Models",
                column: "InventoryId",
                principalTable: "Inventory_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_Model_Inventory_Models_Inventory_ModelId",
                table: "Inventory_Product_Model",
                column: "Inventory_ModelId",
                principalTable: "Inventory_Models",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_Model_Product_Models_ProductId",
                table: "Inventory_Product_Model",
                column: "ProductId",
                principalTable: "Product_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IoT_Data_Models_IoT_Models_IoTModelId",
                table: "IoT_Data_Models",
                column: "IoTModelId",
                principalTable: "IoT_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Login_Log_Models_AspNetUsers_UserIdentityId",
                table: "Login_Log_Models",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Edit_Log_Models_Order_Models_OrderId",
                table: "Order_Edit_Log_Models",
                column: "OrderId",
                principalTable: "Order_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Products_Order_Models_OrderId",
                table: "Order_Products",
                column: "OrderId",
                principalTable: "Order_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Products_Product_Models_ProductId",
                table: "Order_Products",
                column: "ProductId",
                principalTable: "Product_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Edit_Log_Models_Product_Models_ProductId",
                table: "Product_Edit_Log_Models",
                column: "ProductId",
                principalTable: "Product_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Use_Metrail_Models_Material_Models_MetrailId",
                table: "Product_Use_Metrail_Models",
                column: "MetrailId",
                principalTable: "Material_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Use_Metrail_Models_Product_Models_ProductId",
                table: "Product_Use_Metrail_Models",
                column: "ProductId",
                principalTable: "Product_Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Edit_Log_Models_AspNetUsers_UserIdentityId",
                table: "User_Edit_Log_Models",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Log_Models_Inventory_Models_InventoryId",
                table: "Inventory_Log_Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_Model_Inventory_Models_Inventory_ModelId",
                table: "Inventory_Product_Model");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Product_Model_Product_Models_ProductId",
                table: "Inventory_Product_Model");

            migrationBuilder.DropForeignKey(
                name: "FK_IoT_Data_Models_IoT_Models_IoTModelId",
                table: "IoT_Data_Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Login_Log_Models_AspNetUsers_UserIdentityId",
                table: "Login_Log_Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Edit_Log_Models_Order_Models_OrderId",
                table: "Order_Edit_Log_Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Products_Order_Models_OrderId",
                table: "Order_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Products_Product_Models_ProductId",
                table: "Order_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Edit_Log_Models_Product_Models_ProductId",
                table: "Product_Edit_Log_Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Use_Metrail_Models_Material_Models_MetrailId",
                table: "Product_Use_Metrail_Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Use_Metrail_Models_Product_Models_ProductId",
                table: "Product_Use_Metrail_Models");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Edit_Log_Models_AspNetUsers_UserIdentityId",
                table: "User_Edit_Log_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Edit_Log_Models",
                table: "User_Edit_Log_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Use_Metrail_Models",
                table: "Product_Use_Metrail_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Models",
                table: "Product_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product_Edit_Log_Models",
                table: "Product_Edit_Log_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Products",
                table: "Order_Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Models",
                table: "Order_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Edit_Log_Models",
                table: "Order_Edit_Log_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Material_Models",
                table: "Material_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Login_Log_Models",
                table: "Login_Log_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IoT_Models",
                table: "IoT_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IoT_Data_Models",
                table: "IoT_Data_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory_Models",
                table: "Inventory_Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory_Log_Models",
                table: "Inventory_Log_Models");

            migrationBuilder.RenameTable(
                name: "User_Edit_Log_Models",
                newName: "UserEditLogModels");

            migrationBuilder.RenameTable(
                name: "Product_Use_Metrail_Models",
                newName: "ProductUseMetrailModels");

            migrationBuilder.RenameTable(
                name: "Product_Models",
                newName: "ProductModels");

            migrationBuilder.RenameTable(
                name: "Product_Edit_Log_Models",
                newName: "ProductEditLogModels");

            migrationBuilder.RenameTable(
                name: "Order_Products",
                newName: "OrderProducts");

            migrationBuilder.RenameTable(
                name: "Order_Models",
                newName: "OrderModels");

            migrationBuilder.RenameTable(
                name: "Order_Edit_Log_Models",
                newName: "OrderEditLogModels");

            migrationBuilder.RenameTable(
                name: "Material_Models",
                newName: "MaterialModels");

            migrationBuilder.RenameTable(
                name: "Login_Log_Models",
                newName: "LoginLogModels");

            migrationBuilder.RenameTable(
                name: "IoT_Models",
                newName: "IoTModels");

            migrationBuilder.RenameTable(
                name: "IoT_Data_Models",
                newName: "IoTDataModels");

            migrationBuilder.RenameTable(
                name: "Inventory_Models",
                newName: "InventoryModels");

            migrationBuilder.RenameTable(
                name: "Inventory_Log_Models",
                newName: "InventoryLogModels");

            migrationBuilder.RenameIndex(
                name: "IX_User_Edit_Log_Models_UserIdentityId",
                table: "UserEditLogModels",
                newName: "IX_UserEditLogModels_UserIdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Use_Metrail_Models_ProductId",
                table: "ProductUseMetrailModels",
                newName: "IX_ProductUseMetrailModels_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Use_Metrail_Models_MetrailId",
                table: "ProductUseMetrailModels",
                newName: "IX_ProductUseMetrailModels_MetrailId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_Edit_Log_Models_ProductId",
                table: "ProductEditLogModels",
                newName: "IX_ProductEditLogModels_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Products_ProductId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Products_OrderId",
                table: "OrderProducts",
                newName: "IX_OrderProducts_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Edit_Log_Models_OrderId",
                table: "OrderEditLogModels",
                newName: "IX_OrderEditLogModels_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Login_Log_Models_UserIdentityId",
                table: "LoginLogModels",
                newName: "IX_LoginLogModels_UserIdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_IoT_Data_Models_IoTModelId",
                table: "IoTDataModels",
                newName: "IX_IoTDataModels_IoTModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_Log_Models_InventoryId",
                table: "InventoryLogModels",
                newName: "IX_InventoryLogModels_InventoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserEditLogModels",
                table: "UserEditLogModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUseMetrailModels",
                table: "ProductUseMetrailModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductModels",
                table: "ProductModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductEditLogModels",
                table: "ProductEditLogModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderProducts",
                table: "OrderProducts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderModels",
                table: "OrderModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderEditLogModels",
                table: "OrderEditLogModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MaterialModels",
                table: "MaterialModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginLogModels",
                table: "LoginLogModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IoTModels",
                table: "IoTModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IoTDataModels",
                table: "IoTDataModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryModels",
                table: "InventoryModels",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryLogModels",
                table: "InventoryLogModels",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_Model_InventoryModels_Inventory_ModelId",
                table: "Inventory_Product_Model",
                column: "Inventory_ModelId",
                principalTable: "InventoryModels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Product_Model_ProductModels_ProductId",
                table: "Inventory_Product_Model",
                column: "ProductId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogModels_InventoryModels_InventoryId",
                table: "InventoryLogModels",
                column: "InventoryId",
                principalTable: "InventoryModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IoTDataModels_IoTModels_IoTModelId",
                table: "IoTDataModels",
                column: "IoTModelId",
                principalTable: "IoTModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginLogModels_AspNetUsers_UserIdentityId",
                table: "LoginLogModels",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderEditLogModels_OrderModels_OrderId",
                table: "OrderEditLogModels",
                column: "OrderId",
                principalTable: "OrderModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_OrderModels_OrderId",
                table: "OrderProducts",
                column: "OrderId",
                principalTable: "OrderModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProducts_ProductModels_ProductId",
                table: "OrderProducts",
                column: "ProductId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductEditLogModels_ProductModels_ProductId",
                table: "ProductEditLogModels",
                column: "ProductId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUseMetrailModels_MaterialModels_MetrailId",
                table: "ProductUseMetrailModels",
                column: "MetrailId",
                principalTable: "MaterialModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUseMetrailModels_ProductModels_ProductId",
                table: "ProductUseMetrailModels",
                column: "ProductId",
                principalTable: "ProductModels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserEditLogModels_AspNetUsers_UserIdentityId",
                table: "UserEditLogModels",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
