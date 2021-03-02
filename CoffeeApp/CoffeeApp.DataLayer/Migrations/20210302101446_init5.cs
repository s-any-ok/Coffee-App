using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeApp.DataLayer.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrinkId",
                table: "Ingredient",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Drink",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DrinkName = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true),
                    CoffeeMachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drink", x => x.Id);
                });

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
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_Drink_DrinkId",
                table: "Ingredient");

            migrationBuilder.DropTable(
                name: "Drink");

            migrationBuilder.DropIndex(
                name: "IX_Ingredient_DrinkId",
                table: "Ingredient");

            migrationBuilder.DropColumn(
                name: "DrinkId",
                table: "Ingredient");
        }
    }
}
