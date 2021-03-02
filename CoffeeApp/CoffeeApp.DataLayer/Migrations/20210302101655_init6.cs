using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeApp.DataLayer.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Drink_CoffeeMachineId",
                table: "Drink",
                column: "CoffeeMachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_CoffeeMachine_CoffeeMachineId",
                table: "Drink",
                column: "CoffeeMachineId",
                principalTable: "CoffeeMachine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_CoffeeMachine_CoffeeMachineId",
                table: "Drink");

            migrationBuilder.DropIndex(
                name: "IX_Drink_CoffeeMachineId",
                table: "Drink");
        }
    }
}
