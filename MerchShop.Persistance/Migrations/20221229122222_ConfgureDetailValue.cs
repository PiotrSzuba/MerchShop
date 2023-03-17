using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerchShop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ConfgureDetailValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsValue_ItemDetailSections_ItemDetailId",
                table: "ItemsValue");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemDetailId",
                table: "ItemsValue",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ItemsValue",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsValue_ItemDetailSections_ItemDetailId",
                table: "ItemsValue",
                column: "ItemDetailId",
                principalTable: "ItemDetailSections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsValue_ItemDetailSections_ItemDetailId",
                table: "ItemsValue");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemDetailId",
                table: "ItemsValue",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "ItemsValue",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsValue_ItemDetailSections_ItemDetailId",
                table: "ItemsValue",
                column: "ItemDetailId",
                principalTable: "ItemDetailSections",
                principalColumn: "Id");
        }
    }
}
