using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeApp.DataLayer.Migrations
{
    public partial class init13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_DrinkId",
                table: "Ingredient",
                column: "DrinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_Drink_DrinkId",
                table: "Ingredient",
                column: "DrinkId",
                principalTable: "Drink",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Drink_DrinkId",
                table: "Ingredient");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_DrinkId",
                table: "Ingredient");
        }
    }
}
