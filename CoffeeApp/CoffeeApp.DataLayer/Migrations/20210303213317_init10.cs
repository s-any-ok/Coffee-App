using Microsoft.EntityFrameworkCore.Migrations;

namespace CoffeeApp.DataLayer.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Producer",
                table: "Drink");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Producer",
                table: "Drink",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
