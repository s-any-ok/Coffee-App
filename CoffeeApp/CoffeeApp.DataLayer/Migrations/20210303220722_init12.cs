using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeApp.DataLayer.Migrations
{
    public partial class init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_CoffeeMachineId",
                table: "Ingredient",
                column: "CoffeeMachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_CoffeeMachine_CoffeeMachineId",
                table: "Ingredient",
                column: "CoffeeMachineId",
                principalTable: "CoffeeMachine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_CoffeeMachine_CoffeeMachineId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_CoffeeMachineId",
                table: "Ingredient");
        }
    }
}
