namespace CA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CoffeeMachines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoffeeMachineName = c.String(),
                        Producer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CoffeeMachineIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        isDefault = c.Boolean(nullable: false),
                        IngredientName = c.String(),
                        Volume = c.Single(nullable: false),
                        CoffeeMachineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoffeeMachines", t => t.CoffeeMachineId, cascadeDelete: true)
                .Index(t => t.CoffeeMachineId);
            
            CreateTable(
                "dbo.Drinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrinkName = c.String(),
                        CoffeeMachineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CoffeeMachines", t => t.CoffeeMachineId, cascadeDelete: true)
                .Index(t => t.CoffeeMachineId);
            
            CreateTable(
                "dbo.DrinkIngredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientName = c.String(),
                        Volume = c.Single(nullable: false),
                        DrinkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drinks", t => t.DrinkId, cascadeDelete: true)
                .Index(t => t.DrinkId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        DrinkId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drinks", t => t.DrinkId, cascadeDelete: true)
                .Index(t => t.DrinkId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DrinkId", "dbo.Drinks");
            DropForeignKey("dbo.DrinkIngredients", "DrinkId", "dbo.Drinks");
            DropForeignKey("dbo.Drinks", "CoffeeMachineId", "dbo.CoffeeMachines");
            DropForeignKey("dbo.CoffeeMachineIngredients", "CoffeeMachineId", "dbo.CoffeeMachines");
            DropIndex("dbo.Orders", new[] { "DrinkId" });
            DropIndex("dbo.DrinkIngredients", new[] { "DrinkId" });
            DropIndex("dbo.Drinks", new[] { "CoffeeMachineId" });
            DropIndex("dbo.CoffeeMachineIngredients", new[] { "CoffeeMachineId" });
            DropTable("dbo.Orders");
            DropTable("dbo.DrinkIngredients");
            DropTable("dbo.Drinks");
            DropTable("dbo.CoffeeMachineIngredients");
            DropTable("dbo.CoffeeMachines");
        }
    }
}
