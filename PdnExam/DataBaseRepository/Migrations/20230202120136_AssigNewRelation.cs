using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBaseRepository.Migrations
{
    public partial class AssigNewRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductPriceId",
                table: "InvoiceItems",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_ProductPriceId",
                table: "InvoiceItems",
                column: "ProductPriceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_ProductPrices_ProductPriceId",
                table: "InvoiceItems",
                column: "ProductPriceId",
                principalTable: "ProductPrices",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_ProductPrices_ProductPriceId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_ProductPriceId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "ProductPriceId",
                table: "InvoiceItems");
        }
    }
}
