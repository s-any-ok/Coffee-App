using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeApp.DataLayer.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "defaultCoffeeMachine",
                table: "Ingredient");

            migrationBuilder.CreateTable(
                name: "DefaultIngredient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(nullable: true),
                    Volume = table.Column<float>(nullable: false),
                    CoffeeMachineId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultIngredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DefaultIngredient_CoffeeMachine_CoffeeMachineId",
                        column: x => x.CoffeeMachineId,
                        principalTable: "CoffeeMachine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DefaultIngredient_CoffeeMachineId",
                table: "DefaultIngredient",
                column: "CoffeeMachineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DefaultIngredient");

            migrationBuilder.AddColumn<bool>(
                name: "defaultCoffeeMachine",
                table: "Ingredient",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
