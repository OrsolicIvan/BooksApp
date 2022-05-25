using Microsoft.EntityFrameworkCore.Migrations;

namespace Books.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookOrders_CustomerId",
                table: "BookOrders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookOrders_Customers_CustomerId",
                table: "BookOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookOrders_Customers_CustomerId",
                table: "BookOrders");

            migrationBuilder.DropIndex(
                name: "IX_BookOrders_CustomerId",
                table: "BookOrders");
        }
    }
}
