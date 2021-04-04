namespace CA.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drinks", "CoffeeMachineId", "dbo.CoffeeMachines");
            DropIndex("dbo.Drinks", new[] { "CoffeeMachineId" });
            CreateTable(
                "dbo.DrinkCoffeeMachines",
                c => new
                    {
                        Drink_Id = c.Int(nullable: false),
                        CoffeeMachine_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Drink_Id, t.CoffeeMachine_Id })
                .ForeignKey("dbo.Drinks", t => t.Drink_Id, cascadeDelete: true)
                .ForeignKey("dbo.CoffeeMachines", t => t.CoffeeMachine_Id, cascadeDelete: true)
                .Index(t => t.Drink_Id)
                .Index(t => t.CoffeeMachine_Id);
            
            DropColumn("dbo.Drinks", "CoffeeMachineId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drinks", "CoffeeMachineId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DrinkCoffeeMachines", "CoffeeMachine_Id", "dbo.CoffeeMachines");
            DropForeignKey("dbo.DrinkCoffeeMachines", "Drink_Id", "dbo.Drinks");
            DropIndex("dbo.DrinkCoffeeMachines", new[] { "CoffeeMachine_Id" });
            DropIndex("dbo.DrinkCoffeeMachines", new[] { "Drink_Id" });
            DropTable("dbo.DrinkCoffeeMachines");
            CreateIndex("dbo.Drinks", "CoffeeMachineId");
            AddForeignKey("dbo.Drinks", "CoffeeMachineId", "dbo.CoffeeMachines", "Id", cascadeDelete: true);
        }
    }
}
