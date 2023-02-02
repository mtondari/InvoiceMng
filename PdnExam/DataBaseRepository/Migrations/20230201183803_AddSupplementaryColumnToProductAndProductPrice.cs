using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseRepository.Migrations
{
    public partial class AddSupplementaryColumnToProductAndProductPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDateTime",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDateTime",
                table: "ProductPrices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdateDateTime",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "EndDateTime",
                table: "ProductPrices");
        }
    }
}
