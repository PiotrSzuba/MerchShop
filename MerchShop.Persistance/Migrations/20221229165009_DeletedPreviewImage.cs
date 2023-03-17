using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MerchShop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class DeletedPreviewImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviewImage",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ItemTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "ItemTypes");

            migrationBuilder.AddColumn<string>(
                name: "PreviewImage",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
