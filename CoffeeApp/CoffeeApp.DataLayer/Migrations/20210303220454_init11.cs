using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeApp.DataLayer.Migrations
{
    public partial class init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_CoffeeMachine_CoffeeMachineId",
                table: "Drink");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_CoffeeMachine_CoffeeMachineId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Drink_DrinkId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_CoffeeMachineId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_DrinkId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Drink_CoffeeMachineId",
                table: "Drink");

            migrationBuilder.AlterColumn<int>(
                name: "DrinkId",
                table: "Ingredient",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isDrink",
                table: "Ingredient",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isDrink",
                table: "Ingredient");

            migrationBuilder.AlterColumn<int>(
                name: "DrinkId",
                table: "Ingredient",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_CoffeeMachineId",
                table: "Ingredient",
                column: "CoffeeMachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_DrinkId",
                table: "Ingredient",
                column: "DrinkId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_CoffeeMachine_CoffeeMachineId",
                table: "Ingredient",
                column: "CoffeeMachineId",
                principalTable: "CoffeeMachine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Drink_DrinkId",
                table: "Ingredient",
                column: "DrinkId",
                principalTable: "Drink",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
