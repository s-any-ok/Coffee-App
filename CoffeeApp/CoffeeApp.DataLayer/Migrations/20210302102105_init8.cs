using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeApp.DataLayer.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_CoffeeMachine_CoffeeMachineId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_CoffeeMachineId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CoffeeMachineId",
                table: "Order");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoffeeMachineId",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Order_CoffeeMachineId",
                table: "Order",
                column: "CoffeeMachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_CoffeeMachine_CoffeeMachineId",
                table: "Order",
                column: "CoffeeMachineId",
                principalTable: "CoffeeMachine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
