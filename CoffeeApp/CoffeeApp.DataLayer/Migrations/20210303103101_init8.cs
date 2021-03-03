using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeApp.DataLayer.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "Order",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_DrinkId",
                table: "Order",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Drink_DrinkId",
                table: "Order",
                column: "DrinkId",
                principalTable: "Drink",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Drink_DrinkId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_DrinkId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "Order");
        }
    }
}
