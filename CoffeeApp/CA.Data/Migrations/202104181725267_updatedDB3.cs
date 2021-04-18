namespace CA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDB3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IngredientTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.CoffeeMachineIngredients", "IngredientTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.DrinkIngredients", "IngredientTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.CoffeeMachineIngredients", "IngredientTypeId");
            CreateIndex("dbo.DrinkIngredients", "IngredientTypeId");
            AddForeignKey("dbo.CoffeeMachineIngredients", "IngredientTypeId", "dbo.IngredientTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DrinkIngredients", "IngredientTypeId", "dbo.IngredientTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.CoffeeMachineIngredients", "IngredientName");
            DropColumn("dbo.DrinkIngredients", "IngredientName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DrinkIngredients", "IngredientName", c => c.String());
            AddColumn("dbo.CoffeeMachineIngredients", "IngredientName", c => c.String());
            DropForeignKey("dbo.DrinkIngredients", "IngredientTypeId", "dbo.IngredientTypes");
            DropForeignKey("dbo.CoffeeMachineIngredients", "IngredientTypeId", "dbo.IngredientTypes");
            DropIndex("dbo.DrinkIngredients", new[] { "IngredientTypeId" });
            DropIndex("dbo.CoffeeMachineIngredients", new[] { "IngredientTypeId" });
            DropColumn("dbo.DrinkIngredients", "IngredientTypeId");
            DropColumn("dbo.CoffeeMachineIngredients", "IngredientTypeId");
            DropTable("dbo.IngredientTypes");
        }
    }
}
