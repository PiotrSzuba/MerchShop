using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerchShop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetail_Items_ItemId",
                table: "ItemDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemType_Items_ItemId",
                table: "ItemType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemType",
                table: "ItemType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemDetail",
                table: "ItemDetail");

            migrationBuilder.RenameTable(
                name: "ItemType",
                newName: "ItemTypes");

            migrationBuilder.RenameTable(
                name: "ItemDetail",
                newName: "ItemDetails");

            migrationBuilder.RenameIndex(
                name: "IX_ItemType_ItemId",
                table: "ItemTypes",
                newName: "IX_ItemTypes_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemDetail_ItemId",
                table: "ItemDetails",
                newName: "IX_ItemDetails_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTypes",
                table: "ItemTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemDetails",
                table: "ItemDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetails_Items_ItemId",
                table: "ItemDetails",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypes_Items_ItemId",
                table: "ItemTypes",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemDetails_Items_ItemId",
                table: "ItemDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypes_Items_ItemId",
                table: "ItemTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTypes",
                table: "ItemTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemDetails",
                table: "ItemDetails");

            migrationBuilder.RenameTable(
                name: "ItemTypes",
                newName: "ItemType");

            migrationBuilder.RenameTable(
                name: "ItemDetails",
                newName: "ItemDetail");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTypes_ItemId",
                table: "ItemType",
                newName: "IX_ItemType_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_ItemDetails_ItemId",
                table: "ItemDetail",
                newName: "IX_ItemDetail_ItemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemType",
                table: "ItemType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemDetail",
                table: "ItemDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemDetail_Items_ItemId",
                table: "ItemDetail",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItemType_Items_ItemId",
                table: "ItemType",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
